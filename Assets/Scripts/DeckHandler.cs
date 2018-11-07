using System.Collections.Generic;
using UnityEngine;

public class DeckHandler : MonoBehaviour {

    private List<CardAsset> deck;
    private List<GameObject> hand;

    public GameObject spawnPoint;
    public GameObject cardPreFab;

    private void Awake()
    {
        deck = new List<CardAsset>(Resources.LoadAll<CardAsset>("Assets/Resources/Cards"));
    }
}
