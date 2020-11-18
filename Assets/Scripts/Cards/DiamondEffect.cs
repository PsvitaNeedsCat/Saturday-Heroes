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
        m_ID = 1;
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
