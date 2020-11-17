using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card : MonoBehaviour
{
    public enum ECardType
    {
        Attack,
        Effect
    }

    protected int m_ID;
    protected ECardType cardType;
    // Start is called before the first frame update
    protected virtual void Start()
    {

    }

    // Update is called once per frame
    protected virtual void Update()
    {

    }

    public ECardType GetCardType()
    {
        return cardType;
    }
}
