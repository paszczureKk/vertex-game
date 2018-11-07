using System.Collections.Generic;
using UnityEngine;

public class DeckHandler : MonoBehaviour
{
    private static DeckHandler instance;

    [SerializeField]
    private GameObject cardPrefab;
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private int handCap;

    private List<CardAsset> cardData = new List<CardAsset>();
    private List<GameObject> cards = new List<GameObject>();

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

    public CardAsset CardData
    {
        get
        {
            return cardData[Random.Range(0, cardData.Count)];
        }
    }

    public static DeckHandler Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;

        cardData = new List<CardAsset>(Resources.LoadAll<CardAsset>("Cards"));

        for (int i = 0; i < handCap; i++)
        {
            GameObject card = Instantiate<GameObject>(cardPrefab, spawnPoint.transform.position, Quaternion.identity, spawnPoint);
            cards.Add(card);
        }
    }
}
