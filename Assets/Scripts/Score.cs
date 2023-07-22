using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float maxTime = 60.0f; // The maximum time for the timer in seconds

    private float timeRemaining;
    private float score;


    void Start()
    {
        timeRemaining = maxTime;
        UpdateTimerText();
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerText();
        }
        else
        {
            // Handle the end of the timer, e.g., show a game over screen or calculate final score.
            CalculateScore();
        }
    }

    void UpdateTimerText()
    {
        timerText.SetText("Time Remaining: {0:F1} s", timeRemaining); // Display time remaining with 1 decimal place.
    }

    void CalculateScore()
    {
        score = timeRemaining * 100; // Multiply the time remaining by 100 to get the score.
        Debug.Log("Score: " + score);
    }
}
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using TMPro;

//public class Score : MonoBehaviour
//{
//    //[Header("Players")]
//    //public GameObject player1;
//    //public GameObject player2;
//    [SerializeField] TextMeshProUGUI timer;

//    public void TheScore()
//    {
//        int floatTimer = (int)timer;
//    }

//    [Header("Score Text")]
//    public TextMeshProUGUI ScoreText;

//    void Start()
//    {

//    }

//    void Update()
//    {
//        //ScoreText.text = ???.ToString();
//    }
//}
