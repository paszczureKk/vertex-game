using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckHandler : MonoBehaviour {

    [SerializeField]
    private GameObject cardPrefab;
    [SerializeField]
    private Transform parent;

    public int cardCap = 6;
    List<CardAsset> cardData = null;
    List<GameObject> cards = null;

	void Start () {
        cardData = new List<CardAsset>(Resources.LoadAll<CardAsset>("Assets/Resources/Cards"));
        for (int i = 0; i < cardCap; ++i)
            cards.Add(Instantiate(cardPrefab, parent));
    }
	
	void Update () {
		
	}
}
