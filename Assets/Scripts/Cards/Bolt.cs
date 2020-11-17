using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : Card
{
    private float damage = 1f;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        m_ID = 0;
        cardType = ECardType.Attack;

        // raycast to the cards around, if there are effect cards adjacent, they are destroyed and the bolt's damage value is incremented
        // Forward
        Physics.Raycast(transform.position, Vector3.forward, out RaycastHit hit, 1f, LayerMask.NameToLayer("Card"));
        AdjacentPlaceEffect(hit);

        // Back
        Physics.Raycast(transform.position, -Vector3.forward, out hit, 1f, LayerMask.NameToLayer("Card"));
        AdjacentPlaceEffect(hit);

        // Right
        Physics.Raycast(transform.position, Vector3.right, out hit, 1f, LayerMask.NameToLayer("Card"));
        AdjacentPlaceEffect(hit);

        // Left
        Physics.Raycast(transform.position, -Vector3.right, out hit, 1f, LayerMask.NameToLayer("Card"));
        AdjacentPlaceEffect(hit);

        // spawn projectile
    }

    private void AdjacentPlaceEffect(RaycastHit _info)
    {
        Card cardHit = _info.collider.gameObject.GetComponent<Card>();
        if (cardHit)
        {
            if (cardHit.GetCardType() == ECardType.Effect)
            {
                Destroy(cardHit.gameObject);
                damage += 1f;
            }
        }
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
