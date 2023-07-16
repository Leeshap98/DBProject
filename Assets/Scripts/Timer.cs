using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header("Time Text TMP Options")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;
    public bool countDown;

    [Header("Limits")]
    public bool hasLimits;
    public float timerLimit;

    [Header("Format Settings")]
    public bool hasFormat;
    public TimerFormats format;
    private Dictionary<TimerFormats, string> timeFormants = new Dictionary<TimerFormats, string>();

    void Start()
    {
        timeFormants.Add(TimerFormats.Whole, "0");
        timeFormants.Add(TimerFormats.TenthDecimal, "0.0");
        timeFormants.Add(TimerFormats.HunderthsDecimal, "0.00");


    }

    void Update()
    {
        //If countDown is marked, time is counting down
        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;

        if(hasLimits && ((countDown && currentTime <= timerLimit) || (!countDown && currentTime >= timerLimit)))
        {
            currentTime = timerLimit;
            SetTimerText();
            timerText.color = Color.red;
            enabled = false;
        }

        SetTimerText();
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
