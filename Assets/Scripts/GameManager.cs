using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
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
    public TimerScore Timer;

    public void Awake()
    {
        MusicSource.clip = MainMusic;
        MusicSource.Play();
    }

    public void NameEnter()
    {
        Timer.StartTimer();
        NameEnterMenu.SetActive(false);
        MainGame.SetActive(true);
        MusicSource.clip = GameMusic;
        MusicSource.Play();
    }

    public void StartGame()
    {
        MainMenu.SetActive(false);
        NameEnterMenu.SetActive(true);
        
       
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
}
