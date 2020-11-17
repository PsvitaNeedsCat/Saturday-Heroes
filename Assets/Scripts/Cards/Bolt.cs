using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Bolt : Card
{
    private int m_damage = 1;
    [SerializeField] private GameObject m_projectile;
    private List<GameObject> m_destroyTargets = new List<GameObject>();
    private const float m_kTimerDelay = 1f;
    private float m_timer = m_kTimerDelay;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        m_ID = 0;
        m_cardType = ECardType.Attack;

        // raycast to the cards around, if there are effect cards adjacent, they are destroyed and the bolt's damage value is incremented
        // Forward
        Physics.Raycast(transform.position, Vector3.forward, out RaycastHit hit, 1f, LayerMask.GetMask("Card"));
        AdjacentPlaceEffect(hit);

        // Back
        Physics.Raycast(transform.position, -Vector3.forward, out hit, 1f, LayerMask.GetMask("Card"));
        AdjacentPlaceEffect(hit);

        // Right
        Physics.Raycast(transform.position, Vector3.right, out hit, 1f, LayerMask.GetMask("Card"));
        AdjacentPlaceEffect(hit);

        // Left
        Physics.Raycast(transform.position, -Vector3.right, out hit, 1f, LayerMask.GetMask("Card"));
        AdjacentPlaceEffect(hit);

        m_destroyTargets.Add(gameObject);
    }

    private void AdjacentPlaceEffect(RaycastHit _info)
    {
        if (_info.collider)
        {
            Card cardHit = _info.collider.gameObject.GetComponent<Card>();
            if (cardHit)
            {
                if (cardHit.GetCardType() == ECardType.Effect)
                {
                    if (cardHit.GetValid())
                    {
                        cardHit.MarkInvalid();
                        cardHit.transform.DOMove(transform.position, 1f);
                        m_destroyTargets.Add(cardHit.gameObject);
                        m_damage += 1;
                    }
                }
            }
        }
    }

    private void ProjectileHitBoss(Hurtbox _boss, Projectile _projectile)
    {
        Destroy(_projectile.gameObject);

        _boss.ApplyDamage(_projectile.m_damage);
    }

    // Update is called once per frame
    protected override void Update()
    {
        m_timer -= Time.deltaTime;
        if (m_timer <= 0)
        {
            AnimationOver();
        }
        base.Update();
    }

    private void AnimationOver()
    {
        foreach (GameObject target in m_destroyTargets)
        {
            Destroy(target);
        }
        Instantiate(m_projectile, transform.position + 0.5f * Vector3.up, Quaternion.identity)
            .GetComponent<Projectile>()
            .Init(new EDamageType[] { EDamageType.enemy }, m_damage, 4.0f, 8.0f, ProjectileHitBoss);
    }
}
