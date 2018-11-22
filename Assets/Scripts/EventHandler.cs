using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class EventHandler : MonoBehaviour
{
    private static EventHandler instance;

    #region PRIVATE_VARS

    private TimeHandler timeHandler;

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
    private List<Image> eventRequirementsImages;
    [SerializeField]
    private List<Text> eventRequirementsDescriptions;

    #endregion

    #region DATA_CONTAINERS

    private List<EventAsset> events = new List<EventAsset>();

    #endregion

    #region PROPERTIES

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

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;

        events = new List<EventAsset>(Resources.LoadAll<EventAsset>("Events"));
    }

    private void Start()
    {
        timeHandler = TimeHandler.Instance;
        StartCoroutine(Event());
    }

    public IEnumerator Event()
    {
        Debug.Log("bla");
        if (UnityEngine.Random.Range(0.0f, 1.0f) < eventProbability)
            EventOccurs();
        else
        {
            yield return new WaitForSeconds(1);
            StartCoroutine(Event());
        }
    }

    private void EventOccurs()
    {
        timeHandler.enabled = false;

        EventAsset _event = events[UnityEngine.Random.Range(0, events.Count)];
        eventWindow.SetActive(true);
        eventImage.sprite = _event.image;
        eventDescription.text = _event.description;
    }

    private void EventClosed()
    {
        timeHandler.enabled = true;
        StartCoroutine(Event());
    }
}
