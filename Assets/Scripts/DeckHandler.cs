using System.Collections.Generic;
using System.Collections;
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
    //predkosc animacji kart
    [Range(1.0f,3.0f)]
    [SerializeField]
    private float deckAnimationTime = 2.0f;
    //intensywnosc animacji niezgodnosci karty
    [SerializeField]
    [Range(0.0f, 25.0f)]
    private float magnitude = 15.0f;

    #endregion

    #region DATA_CONTAINERS

    //lista wszystkich kart
    private List<CardAsset> cardData = new List<CardAsset>();
    //lista kart na rece
    private List<Card> cards = new List<Card>();
    private List<Card> discardPile = new List<Card>();

    #endregion

    #region PRIVATE_VARS

    //liczba kart na rece
    private int cardsCounter;
    //szerokosc pojedynczej karty
    private float cardWidth;
    //szerokosc pojedynczej karty
    private float cardHeight;
    //predkosc animacji talii
    private float speed;

    #endregion

    #region PUBLIC_CLASSES

    public class Card : IComparable<Card>
    {
        private CardAsset data;
        private GameObject cardObject;

        #region PROPERTIES
        
        public CardAsset Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
                this.CardObject.GetComponent<CardSelfManager>().UpdateCard(value);
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

        public bool Checked
        {
            get
            {
                return cardObject.GetComponent<CardSelfManager>().CardChecked;
            }
        }

        public int Index
        {
            get
            {
                return cardObject.GetComponent<CardSelfManager>().Index;
            }
        }

        #endregion

        public Card()
        {
            DeckHandler dh = DeckHandler.Instance;
            CardObject = Instantiate<GameObject>(dh.cardPrefab, dh.spawnPoint.transform.position, Quaternion.identity, dh.spawnPoint);
            CardObject.GetComponent<CardSelfManager>().Speed = dh.speed;
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

    public float Magnitude
    {
        get
        {
            return magnitude;
        }
    }

    public float CardHeight
    {
        get
        {
            return cardHeight;
        }
    }

    public float SpawnPointY
    {
        get
        {
            return spawnPoint.position.y;
        }
    }

    public float DeckAnimationTime
    {
        get
        {
            return deckAnimationTime;
        }
        set
        {
            deckAnimationTime = value;
        }
    }

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
            //biezaca roznica (daje w wyniku liczbe kart dodanych lub usunietych)
            int diff = value - cardsCounter;

            if (value > 0)
                cardsCounter = value;
            else
                cardsCounter = 0;

            if (diff > 0)
                Settle(diff);
            else
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

    #region AWAKE/START/UPDATE

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }

    private void Start()
    {
        #region CARD_INIT
        cardData = new List<CardAsset>(Resources.LoadAll<CardAsset>("Cards"));

        for (int i = 0; i < handCap; i++)
        {
            new Card();
        }
        #endregion

        //ustawienie parametrów funkcji Settle()
        cardWidth = cards[0].CardObject.GetComponent<RectTransform>().rect.width;
        cardHeight = cards[0].CardObject.GetComponent<RectTransform>().rect.width;

        //ustawienie startowej liczby kart na ręce
        CardsCounter += handCap;

        speed = DeckAnimationTime * TimeHandler.Instance.TimeSpeed;

        foreach (Card card in cards)
            card.CardObject.GetComponent<CardSelfManager>().Speed = speed;
    }

    #endregion

    #region PRIVATE_FUNCTIONS

    //zwraca pozycje na ktorej powinna byc dana karta w obecnym ustawieniu
    private Vector3 GetCardPosition(int index)
    {
        float offset;
        float firstCardPointer;

        if (CardsCounter * cardWidth + (CardsCounter - 1) * 15.0f > handTransform.rect.width)
        {
            firstCardPointer = handTransform.rect.width / 2.0f - cardWidth / 2.0f - 15.0f;
            offset = (handTransform.rect.width - cardWidth - 30.0f) / (CardsCounter - 1);
        }
        else
        {
            if (CardsCounter % 2 == 0)
            {
                firstCardPointer = (cardWidth + 15.0f) * (CardsCounter / 2 - 0.5f);
                offset = cardWidth + 15.0f;
            }
            else
            {
                firstCardPointer = (cardWidth + 15.0f) * (CardsCounter / 2);
                offset = cardWidth + 15.0f;
            }
        }
        return (spawnPoint.position - new Vector3(firstCardPointer, 0.0f, 0.0f) + new Vector3(index * offset, 0.0f, 0.0f));
    }

    //ustawia karty na swoich miejscach - wywolywana w momencie zmiany liczby posiadanych kart lub posortowania ich
    private void Settle(int count = 0)
    {
        for (int i = 0; i < CardsCounter - count; i++)
        {
            cards[i].CardObject.GetComponent<CardSelfManager>().Index = i;
            IEnumerator coroutine = cards[i].CardObject.GetComponent<CardSelfManager>().Move(GetCardPosition(i));
            StartCoroutine(coroutine);
        }
        for (int i = CardsCounter - count; i < CardsCounter; i++)
        {
            cards[i].CardObject.GetComponent<CardSelfManager>().Index = i;
            cards[i].CardObject.GetComponent<CardSelfManager>().InstantMove(GetCardPosition(i));
        }
    }

    #endregion

    #region PUBLIC_FUNCTIONS
    
    //zwraca dane karty na rece o konkretnym indeksie
    public CardAsset GetCard(int index)
    {
        return cards[index].Data;
    }

    public void UseCards()
    {
        int iterator = 0;
        while(iterator < cards.Count)
        {
            if (cards[iterator].Checked == true)
                Discard(index: cards[iterator].Index);
            else
                iterator++;
        }
    }

    //dobiera wskazaną liczbę kart
    public void Draw(int count)
    {
        if (HandCap - CardsCounter > 0)
        {
            int repeat = (HandCap - CardsCounter < count) ? HandCap - CardsCounter : count;

            for (int i = 0; i < repeat; i++)
            {
                if(discardPile.Count == 0)
                {
                    new Card();
                }
                else
                {
                    Card card = discardPile[0];
                    discardPile.RemoveAt(0);
                    card.Data = CardData;
                    card.CardObject.SetActive(true);
                    cards.Add(card);
                }
            }

            CardsCounter += repeat;
        }
    }
    
    public void Discard(int count = 1, int index = -1)
    {
        bool random = (index < 0) ? true : false;

        for (int i = 0; i < count; i++)
        {
            if (random)
                index = UnityEngine.Random.Range(0, cards.Count);

            Card card = cards[index];
            cards.RemoveAt(index);
            discardPile.Add(card);
            //efekt uzycia karty
            card.CardObject.transform.localPosition = spawnPoint.position;
            card.CardObject.SetActive(false);
        }

        CardsCounter -= count;
    }

    public void TimeChange()
    {
        speed = DeckAnimationTime * TimeHandler.Instance.TimeSpeed;
        foreach (Card card in cards)
            card.CardObject.GetComponent<CardSelfManager>().Speed = speed;
        foreach (Card card in discardPile)
            card.CardObject.GetComponent<CardSelfManager>().Speed = speed;
    }

    #endregion

}