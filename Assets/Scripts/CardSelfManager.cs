using UnityEngine;
using UnityEngine.UI;

public class CardSelfManager : MonoBehaviour
{
    private DeckHandler deckHandler;
    
    private Image cardImage;
    private Text cardDescription;
    private Text cardName;

    private void Awake()
    {
        deckHandler = DeckHandler.Instance;

        cardImage = gameObject.transform.Find("CardImage").GetComponent<Image>();
        cardDescription = gameObject.transform.Find("CardDescription").GetComponent<Text>();
        cardName = gameObject.transform.Find("CardName").GetComponent<Text>();
    }

    public void Update(CardAsset card)
    {
        cardImage.sprite = card.image;
        cardDescription.text = card.description;
        cardName.text = card.cardName;
    }
}
