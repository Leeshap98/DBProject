using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] GameObject NameEnterMenu;
    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject MainGame;
    [SerializeField] GameObject OptionsMenu;
    [SerializeField] GameObject Credits;
    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioSource MusicSource;
    [SerializeField] AudioClip ButtonSFX;
    [SerializeField] AudioClip MainMusic;
    [SerializeField] AudioClip GameMusic;
    [SerializeField] Button startButton;
    [SerializeField] GameObject winScreen;
    public TimerScore Timer;

    public void Awake()
    {
        Instance = this;

        MusicSource.clip = MainMusic;
        MusicSource.Play();
        startButton.gameObject.SetActive(false);
    }

    private void Start()
    {
        NameEnterMenu.SetActive(true);
        MainMenu.SetActive(false);
        StartCoroutine(CheckActivePlayers());
    }

    public void WinScreen()
    {
        MainGame.SetActive(false);
        MainMenu.SetActive(false);
        winScreen.SetActive(true);
    }

    public void NameEnter()
    {
        NameEnterMenu.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void StartGame()
    {
        MainGame.SetActive(true);
        Timer.StartTimer();
        MainGame.SetActive(true);
        MusicSource.clip = GameMusic;
        MusicSource.Play();
    }

    public void OptionsOn()
    {
        MainMenu.SetActive(false);
        OptionsMenu.SetActive(true);
    }

    public void MenuOn()
    {
        MainMenu.SetActive(true);
        OptionsMenu.SetActive(false);
        Credits.SetActive(false);
    }

    public void CreditsOn()
    {
        MainMenu.SetActive(false);
        Credits.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ButtonSound()
    {
        SFXSource.clip = ButtonSFX;
        SFXSource.Play();
    }

    IEnumerator CheckActivePlayers()
    {
        UnityWebRequest www = UnityWebRequest.Get("https://localhost:44330/api/TwoPlayerCheck/");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Show results as text
            Debug.Log(www.downloadHandler.text);

            bool twoPlayersActive;
            if (bool.TryParse(www.downloadHandler.text, out twoPlayersActive))
            {
                if (twoPlayersActive)
                {
                    // start button should be active
                    startButton.gameObject.SetActive(true);
                }
                else
                {
                    startButton.gameObject.SetActive(false);
                    Debug.Log("Not enough players active yet");
                }
            }
            else
            {
                Debug.Log("problem with server data");
            }
        }

        yield return new WaitForSeconds(2f);
        StartCoroutine(CheckActivePlayers());
    }
}
