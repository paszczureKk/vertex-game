using UnityEngine;
using UnityEngine.UI;

public class CardSelfManager : MonoBehaviour
{
    private DeckHandler deckHandler;

    private CardAsset card;

    private Image cardImage;
    private Text cardDescription;
    private Text cardName;

    private void Awake()
    {
        deckHandler = DeckHandler.Instance;

        cardImage = gameObject.transform.Find("CardImage").GetComponent<Image>();
        cardDescription = gameObject.transform.Find("CardDescription").GetComponent<Text>();
        cardName = gameObject.transform.Find("CardName").GetComponent<Text>();

        card = deckHandler.CardData;

        cardImage.sprite = card.image;
        cardDescription.text = card.description;
        cardName.text = card.cardName;
    }

    private void Start()
    {
    }
}
