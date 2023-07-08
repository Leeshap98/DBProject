using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject OptionsMenu;
    [SerializeField] GameObject Credits;
    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioSource MusicSource;
    [SerializeField] AudioClip ButtonSFX;
    [SerializeField] AudioClip MainMusic;
    [SerializeField] AudioClip GameMusic;


    public void Awake()
    {
        MusicSource.clip = MainMusic;
        MusicSource.Play();
    }
    public void StartGame()
    {
        MainMenu.SetActive(false);
        // add game canvas - true
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
}
