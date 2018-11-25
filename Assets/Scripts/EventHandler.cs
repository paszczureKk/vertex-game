using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class EventHandler : MonoBehaviour
{
    private static EventHandler instance;

    #region PRIVATE_VARS
    
    private Dictionary<ElementsTypes.ElementType, int> elementsValues;

    //zmienna zezwalajaca na gre kartami
    bool eventLock = false;

    #endregion

    #region EDITOR_VARS

    [Range(0.0f, 1.0f)]
    [SerializeField]
    private float eventProbability = 0.1f;
    [SerializeField]
    private GameObject eventWindow;
    [SerializeField]
    private Image eventImage;
    [SerializeField]
    private Text eventDescription;
    [SerializeField]
    private Button eventButton;
    [SerializeField]
    private List<Image> eventRequirementsImages;
    [SerializeField]
    private List<Text> eventRequirementsDescriptions;

    #endregion

    #region DATA_CONTAINERS

    private List<EventAsset> events = new List<EventAsset>();

    #endregion

    #region PROPERTIES

    public bool EventLock
    {
        get
        {
            return eventLock;
        }
    }

    public static EventHandler Instance
    {
        get
        {
            return instance;
        }
    }

    public float EventProbability
    {
        get
        {
            return eventProbability;
        }
        set
        {
            if (value < 0.0f)
                eventProbability = 0.0f;
            if (value > 1.0f)
                eventProbability = 1.0f;
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

        events = new List<EventAsset>(Resources.LoadAll<EventAsset>("Events"));
        elementsValues = new Dictionary<ElementsTypes.ElementType, int>();
    }

    private void Start()
    {
        StartCoroutine(Event());
    }

    #endregion

    #region PRIVATE_FUNCTIONS

    private void EventWindowUpdate()
    {
        PropertiesReset();

        int index = 0;
        foreach (ElementsTypes.ElementType type in elementsValues.Keys)
        {
            if (elementsValues[type] > 0)
            {
                eventRequirementsImages[index].enabled = true;
                eventRequirementsDescriptions[index].enabled = true;

                eventRequirementsImages[index].sprite = GameHandler.Instance.ElementsImages[type];
                eventRequirementsDescriptions[index].text = elementsValues[type].ToString();

                index++;
            }
        }
    }

    private void PropertiesReset()
    {
        foreach (Image image in eventRequirementsImages)
            image.enabled = false;
        foreach (Text text in eventRequirementsDescriptions)
            text.enabled = false;
    }

    private void EventClosed()
    {
        eventWindow.SetActive(false);

        eventLock = false;

        TimeHandler.Instance.enabled = true;
        StartCoroutine(Event());
    }

    #endregion

    #region PUBLIC_FUNCTIONS

    public IEnumerator Event()
    {
        if (UnityEngine.Random.Range(0.0f, 1.0f) < eventProbability)
            EventOccurs();
        else
        {
            yield return new WaitForSeconds(1);
            StartCoroutine(Event());
        }
    }

    public void EventOccurs()
    {
        TimeHandler.Instance.enabled = false;

        elementsValues.Clear();
        PropertiesReset();

        EventAsset _event = events[UnityEngine.Random.Range(0, events.Count)];
        eventImage.sprite = _event.image;
        eventDescription.text = _event.description;

        int index = 0;

        foreach (ElementsTypes.ElementType type in Enum.GetValues(typeof(ElementsTypes.ElementType)))
        {
            int value = _event.properties[(int)(type)];
            if (value != 0)
            {
                eventRequirementsImages[index].enabled = true;
                eventRequirementsDescriptions[index].enabled = true;

                elementsValues.Add(type, value);

                eventRequirementsImages[index].sprite = GameHandler.Instance.ElementsImages[type];
                eventRequirementsDescriptions[index].text = value.ToString();

                index++;
            }
        }

        eventWindow.SetActive(true);
        eventLock = true;
    }

    public bool EventUpdate(CardAsset card, bool addition)
    {
        bool flag = false;

        List<ElementsTypes.ElementType> keys = new List<ElementsTypes.ElementType>(elementsValues.Keys);
        foreach (ElementsTypes.ElementType type in keys)
        {
            if (addition == true)
                elementsValues[type] -= card.properties[(int)(type)];
            else
                elementsValues[type] += card.properties[(int)(type)];

            flag = true;
        }

        if (flag)
            EventWindowUpdate();

        return flag;
    }

    public void EventCheck()
    {
        bool flag = false;

        foreach(ElementsTypes.ElementType type in elementsValues.Keys)
        {
            if (elementsValues[type] > 0)
                flag = true;
        }

        if (flag)
            MessageHandler.Instance.ShowWindow(MessageHandler.CustomMessageTypes.yesno,
                "Event not completed!",
                "Event is not fulfilled yet. Do You wish to continue?",
                EventClosed);
        else
            EventClosed();
    }

    #endregion

}
