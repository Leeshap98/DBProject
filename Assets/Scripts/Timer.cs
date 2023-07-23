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

    int score = 0;

    public float CurrentTime { get; private set; }

    void Start()
    {
        timeFormants.Add(TimerFormats.Whole, "0");
        timeFormants.Add(TimerFormats.TenthDecimal, "0.0");
        timeFormants.Add(TimerFormats.HunderthsDecimal, "0.00");

        CurrentTime = 11f;
    }

    void Update()
    {
        if (timerActive == true)
        {
            CurrentTime = CurrentTime - Time.deltaTime;

            if (CurrentTime <= 0)
            {
                CurrentTime = 0;
                timerActive = false;
                SetTimerText();
                timerText.color = Color.red;
                enabled = false;
                Debug.Log("Timer Finished");
            }
        }
        SetTimerText();
    }

    public void ResetTimer()
    {
        CurrentTime = 11f;
        timerActive = true;
    }
    public void StopTimer()
    {
        timerActive = false;
    }

    private void SetTimerText()
    {
        timerText.text = hasFormat ? CurrentTime.ToString(timeFormants[format]) : CurrentTime.ToString();
    }

    public enum TimerFormats
    {
        Whole,
        TenthDecimal,
        HunderthsDecimal
    }

    public void RightAns()
    {
        score += (int)CurrentTime * 10;
        Debug.Log(score);
    }
}
