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
    protected ECardType m_cardType;
    protected bool m_valid = true;
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
        return m_cardType;
    }

    public bool GetValid()
    {
        return m_valid;
    }

    public void MarkInvalid()
    {
        m_valid = false;
    }
}
