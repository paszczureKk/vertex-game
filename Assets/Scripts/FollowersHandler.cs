using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class FollowersHandler : MonoBehaviour
{
    private static FollowersHandler instance;

    #region PRIVATE_VARS

    private float prayersFieldWidth;
    private float prayersFieldHeight;
    private float prayerWidth;

    private float prayerProbability;

    private Queue<GameObject> prayers;

    private int prayersSpawned = 0;

    #endregion

    #region EDITOR_VARS

    [Range(100, 5000)]
    [SerializeField]
    private int followersAmount = 500;
    [SerializeField]
    private Transform prayersField;
    [SerializeField]
    private GameObject prayer;

    [SerializeField]
    private Text followersAmountText;

    #endregion

    #region PROPERTIES

    public static FollowersHandler Instance
    {
        get
        {
            return instance;
        }
    }

    public Vector3 OriginPosition
    {
        get
        {
            return prayersField.position;
        }
    }

    public Queue<GameObject> Prayers
    {
        get
        {
            return prayers;
        }
    }

    public int PrayersSpawned
    {
        get
        {
            return prayersSpawned;
        }
        set
        {
            prayersSpawned = value;
        }
    }

    public int FollowersAmount
    {
        get
        {
            return followersAmount;
        }
        set
        {
            followersAmount = (value < 0) ? 0 : value;

            if (followersAmount == 0)
                GameHandler.Instance.GameOver();
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

        prayerProbability = followersAmount / 1000.0f;

        prayersFieldWidth = ((RectTransform)prayersField).rect.width;
        prayersFieldHeight = ((RectTransform)prayersField).rect.height;

        prayerWidth = ((RectTransform)prayer.transform).rect.width;

        prayers = new Queue<GameObject>();
    }

    private void Start()
    {
        for (int i = 0; i < DeckHandler.Instance.HandCap; i++)
        {
            GameObject spawn = Instantiate(prayer, prayersField.position, Quaternion.identity, prayersField);
            spawn.SetActive(false);
            prayers.Enqueue(spawn);
        }

        followersAmountText.text = FollowersAmount.ToString();
    }

    #endregion

    #region PUBLIC_FUNCTIONS

    public bool PrayerCall()
    {
        if(DeckHandler.Instance.CardsCounter + PrayersSpawned < DeckHandler.Instance.HandCap)
        {
            if (UnityEngine.Random.Range(0.0f, 1.0f) < prayerProbability)
            {
                SpawnPrayer();
                return true;
            }
        }
        return false;
    }

    public void FollowersChange(int reward)
    {
        FollowersAmount += reward;
        followersAmountText.text = FollowersAmount.ToString();
    }

    #endregion

    #region PRIVATE_FUNCTIONS

    private void SpawnPrayer()
    {
        float x = UnityEngine.Random.Range(-prayersFieldWidth / 2.0f + prayerWidth, prayersFieldWidth / 2.0f - prayerWidth);
        float y = UnityEngine.Random.Range(-prayersFieldHeight / 2.0f + prayerWidth, prayersFieldHeight / 2.0f - prayerWidth);

        GameObject spawn;

        if (prayers.Count == 0)
        {
            spawn = Instantiate(prayer, prayersField.position, Quaternion.identity, prayersField);
        }
        else
        {
            spawn = prayers.Dequeue();
            spawn.SetActive(true);
        }

        spawn.transform.localPosition = new Vector3(x, y, 0.0f);

        PrayersSpawned++;
    }

    #endregion
}
