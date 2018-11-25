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

    //stan karty - wybrana/niewybrana
    private bool cardChecked = false;

    #endregion

    #region PROPERTIES

    //predkosc animacji
    public float Speed
    {
        get;
        set;
    }

    //obecny index karty na rece
    public int Index
    {
        get;
        set;
    }

    #endregion

    #region AWAKE/START/UPDATE

    private void Awake()
    {
        cardImage = gameObject.transform.Find("CardImage").GetComponent<Image>();
        cardDescription = gameObject.transform.Find("CardDescription").GetComponent<Text>();
        cardName = gameObject.transform.Find("CardName").GetComponent<Text>();
    }

    #endregion

    #region PRIVATE_FUNCTIONS

    //zmienia stan poswiaty karty - prawda wlacza | falsz wylacza
    private void HaloChange(bool turnFlag)
    {
        if (turnFlag == true)
        {
            //zapal
        }
        else
        {
            //zgas
        }
    }

    #endregion

    #region PUBLIC_FUNCTIONS

    //reakcja na najechanie kursorem na obiekt
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(EventHandler.Instance.EventLock == true)
        {
            if (cardChecked == false)
            {
                this.transform.SetAsLastSibling();
                Vector3 destination = new Vector3(0.0f, DeckHandler.Instance.SpawnPointY + DeckHandler.Instance.CardHeight / 2.0f, 0.0f);
                StartCoroutine(MouseHover(destination));
            }
        }
    }

    //reakcja na zabranie kursora z obiektu
    public void OnPointerExit(PointerEventData eventData)
    {
        if(EventHandler.Instance.EventLock == true)
        {
            if (cardChecked == false)
            {
                this.transform.SetSiblingIndex(Index);
                Vector3 destination = new Vector3(0.0f, DeckHandler.Instance.SpawnPointY, 0.0f);
                StartCoroutine(MouseHover(destination));
            }
        }
    }

    //reakcja na klikniecie lpm na obiekt
    public void OnPointerClick(PointerEventData eventData)
    {
        if (EventHandler.Instance.EventLock == true)
        {
            if (cardChecked == false)
            {
                this.transform.SetSiblingIndex(Index);
                Vector3 destination = new Vector3(0.0f, DeckHandler.Instance.SpawnPointY + DeckHandler.Instance.CardHeight / 2.0f, 0.0f);
                StartCoroutine(MouseHover(destination));
                cardChecked = true;
                HaloChange(true);
                EventHandler.Instance.EventUpdate(DeckHandler.Instance.GetCard(Index), true);
            }
            else
            {
                Vector3 destination = new Vector3(0.0f, DeckHandler.Instance.SpawnPointY, 0.0f);
                StartCoroutine(MouseHover(destination));
                cardChecked = false;
                HaloChange(false);
                EventHandler.Instance.EventUpdate(DeckHandler.Instance.GetCard(Index), false);
            }
        }
    }

    //przesuwa karte w czasie wzdluz osi poziomej
    public IEnumerator Move(Vector3 destination)
    {
        float x = gameObject.transform.localPosition.x;

        for (float time = .0f; time < 1; time += Time.deltaTime * Speed)
        {
            float y = gameObject.transform.localPosition.y;
            gameObject.transform.localPosition = Vector3.Lerp(new Vector3(x, y, 0.0f), new Vector3(destination.x, y, 0.0f), time);
            yield return null;
        }

        gameObject.transform.localPosition = new Vector3(destination.x, gameObject.transform.localPosition.y, 0.0f);
    }

    //przesuwa karte w czasie wzdluz osi pionowej
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

    //przesuwa karte natychmiast we wskazane miejsce
    public void InstantMove(Vector3 destination)
    {
        gameObject.transform.localPosition = destination;
    }

    //aktualizuje wyglad karty
    public void UpdateCard(CardAsset card)
    {
        cardImage.sprite = card.image;
        cardDescription.text = card.description;
        cardName.text = card.cardName;
    }

    #endregion

}
