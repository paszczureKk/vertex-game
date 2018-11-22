using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class CardSelfManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    #region PRIVATE_VARS

    private Image cardImage;
    private Text cardDescription;
    private Text cardName;

    #endregion

    #region PROPERTIES

    public float Speed
    {
        get;
        set;
    }

    public int Index
    {
        get;
        set;
    }

    #endregion

    private void Awake()
    {
        cardImage = gameObject.transform.Find("CardImage").GetComponent<Image>();
        cardDescription = gameObject.transform.Find("CardDescription").GetComponent<Text>();
        cardName = gameObject.transform.Find("CardName").GetComponent<Text>();
    }

    public void UpdateCard(CardAsset card)
    {
        cardImage.sprite = card.image;
        cardDescription.text = card.description;
        cardName.text = card.cardName;
    }

    public IEnumerator Move(Vector3 destination)
    {
        float x = gameObject.transform.localPosition.x;

        for(float time = .0f; time<1; time+=Time.deltaTime * Speed)
        {
            float y = gameObject.transform.localPosition.y;
            gameObject.transform.localPosition = Vector3.Lerp(new Vector3(x, y, 0.0f), new Vector3(destination.x, y, 0.0f), time);
            yield return null;
        }

        gameObject.transform.localPosition = new Vector3(destination.x, gameObject.transform.localPosition.y, 0.0f);
    }

    public IEnumerator MouseHover(Vector3 destination)
    {
        StopCoroutine("MouseHover");

        float y = gameObject.transform.localPosition.y;

        for (float time = .0f; time < 1; time += Time.deltaTime * Speed)
        {
            float x = gameObject.transform.localPosition.x;
            gameObject.transform.localPosition = Vector3.Lerp(new Vector3(x, y, 0.0f), new Vector3(x, destination.y, 0.0f), time);
            yield return null;
        }

        gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, destination.y, 0.0f);
    }

    public void InstantMove(Vector3 destination)
    {
        gameObject.transform.localPosition = destination;
        Poof();
    }

    private void Poof()
    {
        //efekt pojawienia sie i znikniecia karty
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.transform.SetAsLastSibling();
        Vector3 destination = new Vector3(0.0f, DeckHandler.Instance.SpawnPointY + DeckHandler.Instance.CardHeight / 2.0f, 0.0f);
        StartCoroutine(MouseHover(destination));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.transform.SetAsLastSibling();
        Vector3 destination = new Vector3(0.0f, DeckHandler.Instance.SpawnPointY, 0.0f);
        StartCoroutine(MouseHover(destination));
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Poof();
        DeckHandler.Instance.Use(Index);
    }
}
