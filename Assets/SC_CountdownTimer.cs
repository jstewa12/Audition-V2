




//please do not delete anything
//do not edit unless necessary


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SC_CountdownTimer : MonoBehaviour
{
    public enum CountdownFormatting { DaysHoursMinutesSeconds, HoursMinutesSeconds, MinutesSeconds, Seconds };
    public CountdownFormatting countdownFormatting = CountdownFormatting.MinutesSeconds; //Controls the way the timer string will be formatted
    public bool showMilliseconds = true; //Whether to show milliseconds in countdown formatting
    public static float countdownTime = 20; //Countdown time in seconds

    Text countdownText;
    public static float countdownInternal;
    public static bool countdownOver = false;

    // Start is called before the first frame update
    void Start()
    {
        countdownText = GetComponent<Text>();
        countdownInternal = countdownTime; //Initialize countdown
    }

    void FixedUpdate()
    {
        if (countdownInternal > 0)
        {
            countdownInternal -= Time.deltaTime;

            if ((countdownInternal <= 5) && (countdownInternal >= 4))
            {
                StartCoroutine(changeBackground(253f, 218f, 13f));
            }

            //Clamp the timer value so it never goes below 0
            if (countdownInternal < 0)
            {
                countdownInternal = 0;
            }

            countdownText.text = FormatTime(countdownInternal, countdownFormatting, showMilliseconds);
        }
        else
        {
            if (!countdownOver)
            {
                countdownOver = true;

                Debug.Log("Countdown has finished running...");

                //Your code here...
            }
        }
    }

    IEnumerator changeBackground(float x, float y, float z)
    {
        Camera.main.GetComponent<Camera>().backgroundColor =
            new Color(x / 255f, y / 255f, z / 255f);
        yield return new WaitForSeconds(1.0f);
        Camera.main.GetComponent<Camera>().backgroundColor =
            new Color(55f / 255f, 77f / 255f, 118f / 255f);
    }

    string FormatTime(double time, CountdownFormatting formatting, bool includeMilliseconds)
    {
        string timeText = "";

        int intTime = (int)time;
        int days = intTime / 86400;
        int hoursTotal = intTime / 3600;
        int hoursFormatted = hoursTotal % 24;
        int minutesTotal = intTime / 60;
        int minutesFormatted = minutesTotal % 60;
        int secondsTotal = intTime;
        int secondsFormatted = intTime % 60;
        int milliseconds = (int)(time * 100);
        milliseconds = milliseconds % 100;

        if (includeMilliseconds)
        {
            if (formatting == CountdownFormatting.DaysHoursMinutesSeconds)
            {
                timeText = string.Format("{0:00}:{1:00}:{2:00}:{3:00}:{4:00}", days, hoursFormatted, minutesFormatted, secondsFormatted, milliseconds);
            }
            else if (formatting == CountdownFormatting.HoursMinutesSeconds)
            {
                timeText = string.Format("{0:00}:{1:00}:{2:00}:{3:00}", hoursTotal, minutesFormatted, secondsFormatted, milliseconds);
            }
            else if (formatting == CountdownFormatting.MinutesSeconds)
            {
                timeText = string.Format("{0:00}:{1:00}:{2:00}", minutesTotal, secondsFormatted, milliseconds);
            }
            else if (formatting == CountdownFormatting.Seconds)
            {
                timeText = string.Format("{0:00}:{1:00}", secondsTotal, milliseconds);
            }
        }
        else
        {
            if (formatting == CountdownFormatting.DaysHoursMinutesSeconds)
            {
                timeText = string.Format("{0:00}:{1:00}:{2:00}:{3:00}", days, hoursFormatted, minutesFormatted, secondsFormatted);
            }
            else if (formatting == CountdownFormatting.HoursMinutesSeconds)
            {
                timeText = string.Format("{0:00}:{1:00}:{2:00}", hoursTotal, minutesFormatted, secondsFormatted);
            }
            else if (formatting == CountdownFormatting.MinutesSeconds)
            {
                timeText = string.Format("{0:00}:{1:00}", minutesTotal, secondsFormatted);
            }
            else if (formatting == CountdownFormatting.Seconds)
            {
                timeText = string.Format("{0:00}", secondsTotal);
            }
        }

        return timeText;
    }
}
