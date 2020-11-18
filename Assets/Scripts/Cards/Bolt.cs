using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Bolt : Card
{
    private int m_damage = 1;
    [SerializeField] private GameObject m_projectile;
    private List<GameObject> m_destroyTargets = new List<GameObject>();

    List<ESuit> m_comboSuitsHit = new List<ESuit>();
    private const float m_kTimerDelay = 1f;
    private float m_timer = m_kTimerDelay;
    private bool m_diamondEffect = false;

    // Start is called before the first frame update
    protected override void Start()
    {
        m_cardType = ECardType.Attack;
        base.Start();
        m_ID = ECard.Bolt;
        m_suit = ESuit.None;
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
            Card cardHit = _info.collider.gameObject.GetComponentInParent<Card>();
            if (cardHit)
            {
                if (cardHit.GetCardType() == ECardType.Effect)
                {
                    if (cardHit.GetValid())
                    {
                        m_damage += 1;
                        if (!m_comboSuitsHit.Contains(CardManager.m_kCardSuits[cardHit.GetCardID()]) && m_comboSuitsHit.Count > 0)
                        {
                            m_damage += 1;
                        }
                        else
                        {
                            m_comboSuitsHit.Add(CardManager.m_kCardSuits[cardHit.GetCardID()]);
                        }
                        if (!m_diamondEffect)
                        {
                            if (cardHit.GetCardID() == ECard.DiamondEffect)
                            {
                                m_diamondEffect = true;
                            }
                        }
                        cardHit.MarkInvalid();
                        
                        cardHit.transform.DOMove(cardHit.transform.position + Vector3.up * 0.25f, 0.75f).SetEase(Ease.InCubic).OnComplete(() =>
                        {
                            cardHit.transform.DOMove(transform.position, 0.25f).SetEase(Ease.OutQuad);
                        });

                        m_destroyTargets.Add(cardHit.gameObject);
                    }
                }
            }
        }
    }
    private void ProjectileHitBoss(Hurtbox _boss, Projectile _projectile)
    {
        Destroy(_projectile.gameObject);
        _boss.ApplyDamage(_projectile.m_damage);
       
        if (m_diamondEffect)
        {
            _boss.GetComponentInParent<BasicBoss>().ApplyDiamondEffectDebuff();
        }
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
        GameObject projectile = Instantiate(m_projectile, transform.position + 0.5f * Vector3.up, Quaternion.identity);
        projectile.GetComponent<Projectile>().Init(new EDamageType[] { EDamageType.enemy }, m_damage, 15.0f, 8.0f, ProjectileHitBoss);

        Vector3 tempScale = projectile.transform.localScale  + Vector3.one * m_damage / 35.0f;

        //tempScale *= m_damage / 35.0f;

        // projectile.transform.localScale = tempScale;
        projectile.transform.DOScale(tempScale, 0.2f).SetEase(Ease.OutCubic);

        AudioManager.Instance.PlaySound("boltFire");

    }
}
