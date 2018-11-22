using System.Collections.Generic;
using UnityEngine;
using System;

public class DeckHandler : MonoBehaviour
{
    private static DeckHandler instance;

    #region EDITOR_VARS

    //wzorzec karty
    [SerializeField]
    private GameObject cardPrefab;
    //miejsce inicjalizacji kart
    [SerializeField]
    private Transform spawnPoint;
    //panel reki
    [SerializeField]
    private RectTransform handTransform;
    //pojemnosc reki
    [SerializeField]
    private int handCap;

    #endregion

    #region DATA_CONTAINERS

    //lista wszystkich kart
    private List<CardAsset> cardData = new List<CardAsset>();
    //lista kart na rece
    private List<Card> cards = new List<Card>();

    #endregion

    #region PRIVATE_VARS

    //liczba kart na rece
    private int cardsCounter;
    //szerokosc pojedynczej karty
    private float cardWidth;
    //pozycja pierwszej karty w wypadku gdy nachodza na siebie (inaczej to spawnPoint)
    private float firstCardPointer;

    #endregion

    #region PUBLIC_CLASSES

    public class Card : IComparable<Card>
    {
        private CardAsset data;
        private GameObject cardObject;

        public CardAsset Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
                this.CardObject.GetComponent<CardSelfManager>().Update(value);
            }
        }

        public GameObject CardObject
        {
            get
            {
                return cardObject;
            }
            set
            {
                cardObject = value;
            }
        }

        public Card()
        {
            DeckHandler dh = DeckHandler.Instance;
            CardObject = Instantiate<GameObject>(dh.cardPrefab, dh.spawnPoint.transform.position, Quaternion.identity, dh.spawnPoint);
            Data = dh.CardData;
            dh.cards.Add(this);
        }

        public int CompareTo(Card other)
        {
            if (this.data.level == other.data.level)
            {
                return this.data.cardName.CompareTo(other.data.cardName);
            }
            else
                return this.data.level - other.data.level;
        }
    }

    #endregion

    #region PROPERTIES

    public int HandCap
    {
        get
        {
            return handCap;
        }
        set
        {
            if (value < 3)
                handCap = 3;
            else
                handCap = value;
        }
    }

    public int CardsCounter
    {
        get
        {
            return cardsCounter;
        }
        set
        {
            if (value < 0)
                cardsCounter = 0;
            else
                cardsCounter = value;

            Settle();
        }
    }

    public CardAsset CardData
    {
        get
        {
            return cardData[UnityEngine.Random.Range(0, cardData.Count)];
        }
    }

    public static DeckHandler Instance
    {
        get
        {
            return instance;
        }
    }

    #endregion

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;

        #region CARD_INIT
        cardData = new List<CardAsset>(Resources.LoadAll<CardAsset>("Cards"));

        for (int i = 0; i < handCap; i++)
        {
            Card card = new Card();
        }
        #endregion

        //ustawienie parametrów funkcji Settle()
        cardWidth = cards[0].CardObject.GetComponent<RectTransform>().rect.width;

        //ustawienie startowej liczby kart na ręce
        CardsCounter += handCap;
    }

    //ustawia karty na swoich miejscach - wywolywana w momencie zmiany liczby posiadanych kart lub posortowania ich
    private void Settle()
    {
        if (CardsCounter * cardWidth + (CardsCounter - 1) * 15.0f > handTransform.rect.width)
        {
            firstCardPointer = handTransform.rect.width / 2.0f - cardWidth / 2.0f - 15.0f;
            float offset = (handTransform.rect.width - cardWidth - 30.0f) / (CardsCounter - 1);
            for (int i = 0; i < CardsCounter; i++)
            {
                cards[i].CardObject.transform.localPosition -= new Vector3(firstCardPointer, 0.0f, 0.0f) - new Vector3(i * offset, 0.0f, 0.0f);
            }
        }
        else
        {
            if (CardsCounter % 2 == 0)
            {
                for (int i = 0; i < CardsCounter; i++)
                {
                    firstCardPointer = (cardWidth + 15.0f) * (CardsCounter / 2 - 0.5f);
                    float offset = cardWidth + 15.0f;
                    cards[i].CardObject.transform.localPosition -= new Vector3(firstCardPointer, 0.0f, 0.0f) - new Vector3(i * offset, 0.0f, 0.0f);
                }
            }
            else
            {
                for (int i = 0; i < CardsCounter; i++)
                {
                    firstCardPointer = (cardWidth + 15.0f) * (CardsCounter / 2);
                    float offset = cardWidth + 15.0f;
                    cards[i].CardObject.transform.localPosition -= new Vector3(firstCardPointer, 0.0f, 0.0f) - new Vector3(i * offset, 0.0f, 0.0f);
                }
            }
        }
    }
}