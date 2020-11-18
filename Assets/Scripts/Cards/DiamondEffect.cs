using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondEffect : Card
{
    // Start is called before the first frame update
    protected override void Start()
    {
        m_cardType = ECardType.Effect;
        base.Start();
        m_ID = ECard.DiamondEffect;
        m_suit = ESuit.Diamonds;
        m_cardType = ECardType.Effect;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
