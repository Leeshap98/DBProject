using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class QuestionManager : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text Question_text;
    [SerializeField] TMPro.TMP_Text Ans1_text;
    [SerializeField] TMPro.TMP_Text Ans2_text;
    [SerializeField] TMPro.TMP_Text Ans3_text;
    [SerializeField] TMPro.TMP_Text Ans4_text;
    [SerializeField] GameObject button1;

    int questionNum = 1;

    public TimerScore timer;
    public GameManager manager;
    [SerializeField] UpdatePlayer updatePlayer;

    
    void Start()
    {
        StartCoroutine(GetQuestion(questionNum));
    }

    public void NextQuestion()
    {
        if(questionNum > 4)
        {
            StartCoroutine(PlayerFinish(updatePlayer.Name));
            StartCoroutine(CheckIfBothPlayersFinished());
            return;
        }

        timer.DisplayAnswerBackground(false);
        timer.ChangeStateAnswerButtons(true);
        timer.ResetTimer();
        questionNum++;
        timer.resetBG();
        timer.StartTimer();
        manager.MusicSource.clip = manager.GameMusic;
        manager.MusicSource.Play();


        StartCoroutine(GetQuestion(questionNum));
    }

    IEnumerator CheckIfBothPlayersFinished()
    {
        UnityWebRequest www = UnityWebRequest.Get("https://localhost:44330/api/CheckIfBothPlayersFinished");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("2 players finished");

            bool twoPlayersFinished;
            if (bool.TryParse(www.downloadHandler.text, out twoPlayersFinished))
            {
                if (twoPlayersFinished)
                {
                    GameManager.Instance.WinScreen();
                }
                else
                {
                    GameManager.Instance.DisplayWatingScreen();
                }
            }
            else
            {
                Debug.Log("problem with server data");
            }
        }

        yield return new WaitForSeconds(2f);
        StartCoroutine(CheckIfBothPlayersFinished());
    }

    IEnumerator PlayerFinish(string name)
    {
        UnityWebRequest www = UnityWebRequest.Get($"https://localhost:44330/api/PlayerFinished?name={name}");
        yield return www.SendWebRequest(); 

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Player finished");
        }
    }

    IEnumerator GetQuestion(int id)
    {
        UnityWebRequest www = UnityWebRequest.Get("https://localhost:44330/api/GetQuestion/" + id);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Show results as text
            Debug.Log(www.downloadHandler.text);

                

            Question question = JsonUtility.FromJson<Question>(www.downloadHandler.text);
          
            if (question != null)
            {
                Question_text.text = question.text;
                Ans1_text.text = question.ans1;
                Ans2_text.text = question.ans2;
                Ans3_text.text = question.ans3;
                Ans4_text.text = question.ans4;
                Debug.Log(question.correctID.ToString());
            }
        }
    }
}
