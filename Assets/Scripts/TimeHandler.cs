using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class TimeHandler : MonoBehaviour
{
    private static TimeHandler instance;

    #region PRIVATE_VARS

    private float dayDuration;

    private float time = 0f;
    private float timeSpeed = 3.0f;

    private int day = 1;
    private int month = 1;
    private int year = 1;

    private bool timeLocked = false;
    private bool isDay = true;

    private Color dayColor;
    private Color nightColor;

    private List<string> calls;

    #endregion

    #region EDITOR_VARS

    [SerializeField]
    private Text calendarText;
    [SerializeField]
    private Text speedText;
    [SerializeField]
    private Slider dayTimeSlider;
    [SerializeField]
    private Image currentDayTime;
    [SerializeField]
    private Image nextDayTime;

    #endregion

    #region PROPERTIES

    public static TimeHandler Instance
    {
        get
        {
            return instance;
        }
    }

    public float TimeSpeed
    {
        get
        {
            return timeSpeed;
        }
        set
        {
            timeSpeed = value;
            if (timeSpeed < 1.0f) timeSpeed = 1.0f;
            if (timeSpeed > 5.0f) timeSpeed = 5.0f;
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

        dayDuration = gameObject.GetComponentInChildren<Slider>().maxValue;

        dayColor = currentDayTime.color;
        nightColor = nextDayTime.color;

        calls = new List<string>();
    }

    private void Start()
    {
        calendarText.text = day + monthToString(month);
        speedText.text = TimeSpeed.ToString();
    }

    private void FixedUpdate()
    {
        if(timeLocked == false)
        {
            time += timeSpeed * Time.deltaTime;

            if (time > dayDuration)
            {
                DayChange();
            }

            dayTimeSlider.value = time;
        }
    }

    #endregion

    #region PRIVATE_FUNCTIONS

    private string monthToString(int n)
    {
        switch (n)
        {
            case 1:
                return " I";
            case 2:
                return " II";
            case 3:
                return " III";
            case 4:
                return " IV";
            case 5:
                return " V";
            case 6:
                return " VI";
            case 7:
                return " VII";
            case 8:
                return " VIII";
            case 9:
                return " IX";
            case 10:
                return " X";
            case 11:
                return " XI";
            case 12:
                return " XII";
            default:
                return "Error";
        }
    }

    private int monthDayCount(int n)
    {
        switch (n)
        {
            case 1:
            case 3:
            case 5:
            case 7:
            case 8:
            case 10:
            case 12:
                return 31;
            case 4:
            case 6:
            case 9:
            case 11:
                return 30;
            case 2:
                if (year == 0)
                    return 29;
                else
                    return 28;
            default:
                return -1;
        }
    }

    private void DayChange()
    {
        if(isDay == true)
        {
            isDay = false;

            currentDayTime.color = nightColor;
            nextDayTime.color = dayColor;
        }
        else
        {
            day++;

            if (day > monthDayCount(month))
            {
                month++;
                day = 1;

                if(month > 12)
                {
                    month = 1;
                    year = (year + 1) % 4;
                }
            }

            isDay = true;
            
            calendarText.text = day + monthToString(month);

            currentDayTime.color = dayColor;
            nextDayTime.color = nightColor;
        }

        time = 0;

        if (EventHandler.Instance.EventCall() == true)
            TimeLock("Event");

        FollowersHandler.Instance.PrayerCall();
    }

    private void TimeLock(string callName)
    {
        calls.Add(callName);
        timeLocked = true;
    }

    public void TimeUnlock(string callName)
    {
        calls.Remove(callName);

        if (calls.Count == 0)
            timeLocked = false;
    }

    #endregion

    #region PUBLIC_FUNCTIONS

    public void TimeChange(int value)
    {
        TimeSpeed += value;
        speedText.text = TimeSpeed.ToString();

        DeckHandler.Instance.TimeChange();
    }

    #endregion

}
