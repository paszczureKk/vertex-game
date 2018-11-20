using UnityEngine;
using UnityEngine.UI;

public class TimeHandler : MonoBehaviour {

    private float time = 0f;
    private float dayDuration = 10f;
    private float timeSpeed;
    private int day = 1;
    private int month = 1;
    public Text calendarText;
    public Slider dayTimeSlider;

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
                return 29;
            default:
                return -1;
        }
    }

    private void Start()
    {
        timeSpeed = GameHandler.Instance.TimeSpeed;
        calendarText.text = day + monthToString(month);
    }

    private void Update()
    {
        time += 3 * timeSpeed * Time.deltaTime;
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
            month = 1;
        dayTimeSlider.value = time;
    }
}
