using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public const int kBolt = 0;
    public const int kDiamondEffect = 1;
    public const int kHeartEffect = 2;
    public const int kUniqueCardCount = 3;

    public struct CardData
    {
        public int m_ID;
        public Sprite GetSprite()
        {
            return GetCardSprite(m_ID);
        }
        public GameObject GetPrefab()
        {
            return GetCardPrefab(m_ID);
        }
        public CardData(int _ID)
        {
            m_ID = _ID;
        }
    }


    [SerializeField] private RectTransform[] m_cardsInterface;
    [SerializeField] private Sprite[] m_cardImages;
    [SerializeField] private GameObject[] m_cardPrefabs;
    private static List<Image>[] m_cardSpritesOnUI = new List<Image>[2];
    private static int[] m_selectedCard = { 0, 0 };
    public static List<CardData>[] m_cards = new List<CardData>[2];

    private static CardManager m_instance;
    public static CardManager GetInstance()
    {
        return m_instance;
    }

    public static Sprite GetCardSprite(int _ID)
    {
        return m_instance.m_cardImages[_ID];
    }

    public static GameObject GetCardPrefab(int _ID)
    {
        return m_instance.m_cardPrefabs[_ID];
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
            m_cards[i] = new List<CardData>() { new CardData(kBolt), new CardData(kBolt), new CardData(kBolt), new CardData(kDiamondEffect), new CardData(kDiamondEffect), new CardData(kHeartEffect) };

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

            UpdateUI(i);
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

        // center card
        if (m_cards[_player].Count > 0)
        {
            m_cardSpritesOnUI[_player][2].sprite = m_cards[_player][m_selectedCard[_player]].GetSprite();
            Color temp = m_cardSpritesOnUI[_player][2].color;
            temp.a = 1;
            m_cardSpritesOnUI[_player][2].color = temp;
        }
        else
        {
            Color temp = m_cardSpritesOnUI[_player][2].color;
            temp.a = 0;
            m_cardSpritesOnUI[_player][2].color = temp;
        }

        // left card
        int index = m_selectedCard[_player] - 1;
        if (index >= 0)
        {
            m_cardSpritesOnUI[_player][1].sprite = m_cards[_player][index].GetSprite();
            Color temp = m_cardSpritesOnUI[_player][1].color;
            temp.a = 1;
            m_cardSpritesOnUI[_player][1].color = temp;
        }
        else
        {
            Color temp = m_cardSpritesOnUI[_player][1].color;
            temp.a = 0;
            m_cardSpritesOnUI[_player][1].color = temp;
        }

        // right card
        index = m_selectedCard[_player] + 1;
        if (index < m_cards[_player].Count)
        {
            m_cardSpritesOnUI[_player][3].sprite = m_cards[_player][index].GetSprite();
            Color temp = m_cardSpritesOnUI[_player][3].color;
            temp.a = 1;
            m_cardSpritesOnUI[_player][3].color = temp;
        }
        else
        {
            Color temp = m_cardSpritesOnUI[_player][3].color;
            temp.a = 0;
            m_cardSpritesOnUI[_player][3].color = temp;
        }

        // leftmost card
        index = m_selectedCard[_player] - 2;
        if (index >= 0)
        {
            m_cardSpritesOnUI[_player][0].sprite = m_cards[_player][index].GetSprite();
            Color temp = m_cardSpritesOnUI[_player][0].color;
            temp.a = 1;
            m_cardSpritesOnUI[_player][0].color = temp;
        }
        else
        {
            Color temp = m_cardSpritesOnUI[_player][0].color;
            temp.a = 0;
            m_cardSpritesOnUI[_player][0].color = temp;
        }

        // rightmost card
        index = m_selectedCard[_player] + 2;
        if (index < m_cards[_player].Count)
        {
            m_cardSpritesOnUI[_player][4].sprite = m_cards[_player][index].GetSprite();
            Color temp = m_cardSpritesOnUI[_player][4].color;
            temp.a = 1;
            m_cardSpritesOnUI[_player][4].color = temp;
        }
        else
        {
            Color temp = m_cardSpritesOnUI[_player][4].color;
            temp.a = 0;
            m_cardSpritesOnUI[_player][4].color = temp;
        }
    }

    public static void SelectNextCard(int _player)
    {
        // incrememnt _player's selected card
        m_selectedCard[_player]++;

        //Debug.Log("DEBUG: SelectNextCard");

        UpdateUI(_player);
    }

    public static void SelectPreviousCard(int _player)
    {
        // decrememnt _player's selected card
        m_selectedCard[_player]--;

        //Debug.Log("DEBUG: SelectPreviousCard");

        UpdateUI(_player);
    }

    public static void UseSelectedCard(int _player)
    {
        m_cards[_player].RemoveAt(m_selectedCard[_player]);

        //Debug.Log("DEBUG: UseSelectedCard");

        UpdateUI(_player);
    }

    public static CardData GetSelectedCard(int _player)
    {
        return m_cards[_player][m_selectedCard[_player]];
    }

    public static void GiveRandomCard(int _player)
    {
        m_cards[_player].Add(new CardData(Random.Range(0, kUniqueCardCount)));
        UpdateUI(_player);
    }
}
