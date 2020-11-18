using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ECardType
{
    Attack,
    Effect
}

public enum ECard
{
    None,
    Bolt,
    DiamondEffect,
    HeartEffect
}

public enum ESuit
{
    None,
    Diamonds,
    Hearts
}

public struct CardData
{
    public ECard ID { get; }
    public ESuit Suit { get; }
    public Sprite GetSprite()
    {
        return CardManager.GetCardSprite(((int)ID) - 1);
    }
    public GameObject GetPrefab()
    {
        return CardManager.GetCardPrefab(((int)ID) - 1);
    }
    public CardData(ECard _ID)
    {
        ID = _ID;
        if (ID == ECard.None)
        {
            Suit = ESuit.None;
        }
        else
        {
            Suit = CardManager.m_kCardSuits[ID - 1];
        }
    }
}

public abstract class Card : MonoBehaviour
{
    protected ECard m_ID;
    protected ESuit m_suit;
    protected ECardType m_cardType;
    protected bool m_valid = true;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        if (m_cardType == ECardType.Attack)
        {
            AudioManager.Instance.PlaySound("playActiveCard");
        }
        else if (m_cardType == ECardType.Effect)
        {
            AudioManager.Instance.PlaySound("playEffectCard");
        }
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

    public ECard GetCardID()
    {
        return m_ID;
    }
}
