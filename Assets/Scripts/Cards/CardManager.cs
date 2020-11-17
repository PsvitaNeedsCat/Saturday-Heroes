using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public const int kBolt = 0;
    public const int kDiamondEffect = 1;
    public const int kHeartEffect = 2;

    public struct CardData
    {
        public int m_ID;
        public Sprite GetSprite()
        {
            return GetCardSprite(m_ID);
        }

        public CardData(int _ID)
        {
            m_ID = _ID;
        }
    }


    [SerializeField] private RectTransform[] m_cardsInterface;
    private static List<Image>[] m_cardSpritesOnUI;
    [SerializeField] private Sprite[] m_cardImages;
    private static int[] m_selectedCard = { 0, 0 };
    public static List<CardData>[] m_cards;

    private static CardManager m_instance;
    public static CardManager GetInstance()
    {
        return m_instance;
    }

    public static Sprite GetCardSprite(int _ID)
    {
        return m_instance.m_cardImages[_ID];
    }

    private void Awake()
    {
        m_instance = this;
    }

    private void Start()
    {
        // for each player
        for (int i = 0; i < 2; i++)
        {
            // define each player's cards.
            m_cards[i] = new List<CardData>() { new CardData(kBolt), new CardData(kBolt), new CardData(kBolt) };

            // set up sprite references to make changing UI easy in future.
            m_cardSpritesOnUI[i] = new List<Image>
            {
                // this matches the layout in the canvas. The order is weird so that the cards are left to right in the List, but drawn in correct order on the UI.
                m_cardsInterface[i].GetChild(1).GetComponent<Image>(),
                m_cardsInterface[i].GetChild(3).GetComponent<Image>(),
                m_cardsInterface[i].GetChild(4).GetComponent<Image>(),
                m_cardsInterface[i].GetChild(2).GetComponent<Image>(),
                m_cardsInterface[i].GetChild(0).GetComponent<Image>(),
            };
        }
    }

    private void Update()
    {
        // for each player
        //for (int i = 0; i < 2; i++)
        //{
        //
        //}
    }

    private static void UpdateUI(int _player)
    {
        // if the _player's selected card is now below 0 (it can't be)
        if (m_selectedCard[_player] < 0)
        {
            // set the _player's selected card to be the final card.
            m_selectedCard[_player] = m_cards[_player].Count - 1;
        }

        // if the _player's selected card is now above the _player's number of cards (it can't be)
        if (m_selectedCard[_player] >= m_cards[_player].Count)
        {
            // set the _player's selected card to be the first card.
            m_selectedCard[_player] = 0;
        }

        // leftmost card
        int index = m_selectedCard[_player] - 2;
        if (index < 0)
        {
            index += m_cards[_player].Count;
        }
        m_cardSpritesOnUI[_player][0].sprite = m_cards[_player][index].GetSprite();

        // left card
        index = m_selectedCard[_player] - 1;
        if (index < 0)
        {
            index += m_cards[_player].Count;
        }
        m_cardSpritesOnUI[_player][1].sprite = m_cards[_player][index].GetSprite();

        // center card
        m_cardSpritesOnUI[_player][2].sprite = m_cards[_player][m_selectedCard[_player]].GetSprite();

        // right card
        index = m_selectedCard[_player] + 1;
        if (index >= m_cards[_player].Count)
        {
            index -= m_cards[_player].Count;
        }
        m_cardSpritesOnUI[_player][3].sprite = m_cards[_player][index].GetSprite();

        // rightmost card
        index = m_selectedCard[_player] + 2;
        if (index >= m_cards[_player].Count)
        {
            index -= m_cards[_player].Count;
        }
        m_cardSpritesOnUI[_player][4].sprite = m_cards[_player][index].GetSprite();
    }

    public static void SelectNextCard(int _player)
    {
        // incrememnt _player's selected card
        m_selectedCard[_player]++;

        UpdateUI(_player);
    }

    public static void SelectPreviousCard(int _player)
    {
        // decrememnt _player's selected card
        m_selectedCard[_player]--;

        UpdateUI(_player);
    }

    public static void UseSelectedCard(int _player)
    {
        m_cards[_player].RemoveAt(m_selectedCard[_player]);

        UpdateUI(_player);
    }
}
