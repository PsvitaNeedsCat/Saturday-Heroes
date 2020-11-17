using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartEffect : Card
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        m_ID = 2;
        cardType = ECardType.Effect;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
