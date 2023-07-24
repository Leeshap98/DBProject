using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;

public class TimerScore : MonoBehaviour
{
    [Header("Buttons")]
    public GameObject NextButton;

    [Header("Timer Text")]
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI ScoreEndScreenText;
    public TextMeshProUGUI TimeEndScreenText;

    [Header("Format Settings")]
    public bool hasFormat;
    public TimerFormats format;
    private Dictionary<TimerFormats, string> timeFormants = new Dictionary<TimerFormats, string>();

    [Header("Answer Backgrounds")]
    public GameObject Ans1BG;
    public GameObject Ans2BG;
    public GameObject Ans3BG;
    public GameObject Ans4BG;

    private bool timerActive = false;
    private int scoreCount = 0;

    public float CurrentTime { get; private set; }

    // Add this variable to set the initial time for the timer
    private float initialTime = 10.0f;

    // Add this variable to store the original time for resetting the timer
    private float originalTime;

    void Start()
    {
        timeFormants.Add(TimerFormats.Whole, "0");
        timeFormants.Add(TimerFormats.TenthDecimal, "0.0");
        timeFormants.Add(TimerFormats.HunderthsDecimal, "0.00");

        CurrentTime = initialTime;
        originalTime = initialTime;
        SetTimerText();
    }

    void Update()
    {
        if (timerActive == true)
        {
            CurrentTime = Mathf.Max(0, CurrentTime - Time.deltaTime);

            if (CurrentTime <= 0)
            {
                WrongAns();
                StopTimer();
                SetTimerText();
                timerText.color = Color.red;
                //enabled = false;
                Debug.Log("Timer Finished");

                // Emily added + needs to be checked - Call the function to send the player's name and score to the server
                SendPlayerScoreToServer();
            }
        }
        SetTimerText();

        // Setting the End Screen
        // Testing which way is better
        TimeEndScreenText.SetText("It took you " + scoreCount / 10f + " Seconds to answer");
        ScoreEndScreenText.text = "Your Score is: " + scoreCount;
    }

    public void StartTimer()
    {
        CurrentTime = initialTime;
        timerActive = true;
    }

    public void ResetTimer()
    {
        CurrentTime = originalTime;
        timerActive = true;
        timerText.color = Color.white;
        SetTimerText(); // Update the timer text to the original time
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

    public void RightAns() // connect to right answers buttons
    {
        NextButton.SetActive(true);
        StopTimer();
        Ans1BG.SetActive(true);
        Ans2BG.SetActive(true);
        Ans3BG.SetActive(true);
        Ans4BG.SetActive(true);
        scoreCount += (int)CurrentTime * 10;
        Debug.Log(scoreCount);
        scoreText.text = "Score: " + scoreCount.ToString();
    }

    public void WrongAns() // connect to wrong answers
    {
        NextButton.SetActive(true);
        Ans1BG.SetActive(true);
        Ans2BG.SetActive(true);
        Ans3BG.SetActive(true);
        Ans4BG.SetActive(true);
        StopTimer();
    }

    public void resetBG() // connect to next button
    {
        NextButton.SetActive(false);
        Ans1BG.SetActive(false);
        Ans2BG.SetActive(false);
        Ans3BG.SetActive(false);
        Ans4BG.SetActive(false);
    }

    // Emily added + needs to be checked
    private void SendPlayerScoreToServer()
    {
        // Replace the URL with the actual server API endpoint for updating player scores
        string serverURL = "https://localhost:44330/api/UpdatePlayerScore";

        // Change "PlayerName" to the actual player's name entered in the game
        string playerName = "PlayerName";

        // Prepare the URL with the player's name and score as parameters
        string urlWithParameters = $"{serverURL}?name={playerName}&score={scoreCount}";

        StartCoroutine(SendScoreRequest(urlWithParameters));
    }

    IEnumerator SendScoreRequest(string url)
    {
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Player score sent to the server successfully!");
        }
    }
}
