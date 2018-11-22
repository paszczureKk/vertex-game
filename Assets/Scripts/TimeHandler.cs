using UnityEngine;
using UnityEngine.UI;

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

    #endregion

    #region EDITOR_VARS

    [SerializeField]
    private Text calendarText;
    [SerializeField]
    private Text speedText;
    [SerializeField]
    private Slider dayTimeSlider;

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

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;

        dayDuration = gameObject.GetComponentInChildren<Slider>().maxValue;
    }

    private void Start()
    {
        calendarText.text = day + monthToString(month);
        speedText.text = TimeSpeed.ToString();
    }

    private void FixedUpdate()
    {
        time += timeSpeed * Time.deltaTime;
        if (time >= dayDuration)
        {
            ++day;
            time = 0;
            calendarText.text = day + monthToString(month);
        }
        if (day >= monthDayCount(month))
        {
            ++month;
            day = 1;
        }
        if (month >= 12)
        {
            month = 1;
            year = (year + 1) % 4;
        }
        dayTimeSlider.value = time;
    }

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

    public void TimeChange(int value)
    {
        TimeSpeed += value;
        speedText.text = TimeSpeed.ToString();

        DeckHandler.Instance.TimeChange();
    }
}
