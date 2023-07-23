using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header("Timer Text")]
    public TextMeshProUGUI timerText;

    [Header("Format Settings")]
    public bool hasFormat;
    public TimerFormats format;
    private Dictionary<TimerFormats, string> timeFormants = new Dictionary<TimerFormats, string>();

    private bool timerActive = true;
    private float currentTime;

    void Start()
    {
        timeFormants.Add(TimerFormats.Whole, "0");
        timeFormants.Add(TimerFormats.TenthDecimal, "0.0");
        timeFormants.Add(TimerFormats.HunderthsDecimal, "0.00");

        currentTime = 11f;
    }

    void Update()
    {
        if (timerActive == true)
        {
            currentTime = currentTime - Time.deltaTime;

            if (currentTime <= 0)
            {
                currentTime = 0;
                timerActive = false;
                SetTimerText();
                timerText.color = Color.red;
                enabled = false;
                //Start();
                Debug.Log("Timer Finished");
            }
        }

        SetTimerText();
    }

    public void ResetTimer()
    {
        currentTime = 11f;
        timerActive = true;
    }
    public void StopTimer()
    {
        timerActive = false;
    }

    private void SetTimerText()
    {
        timerText.text = hasFormat ? currentTime.ToString(timeFormants[format]) : currentTime.ToString();
    }

    public enum TimerFormats
    {
        Whole,
        TenthDecimal,
        HunderthsDecimal
    }
}
