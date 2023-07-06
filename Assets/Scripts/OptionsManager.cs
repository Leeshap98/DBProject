using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class OptionsManager : MonoBehaviour
{

    [SerializeField] AudioMixer _MusicMixer;
    [SerializeField] AudioMixer _SFXMixer;
    [SerializeField] Slider _MusicSlider;
    [SerializeField] Slider _SFXSlider;
    [SerializeField] Toggle _ScreenToggle;

    private void Awake()
    {
        _ScreenToggle.onValueChanged.AddListener(FullScreen);
    }
    public void SetMusicVolume()
    {
        float volume = _MusicSlider.value;
        _MusicMixer.SetFloat("MVol", volume);
    }
    public void SetSFXVolume()
    {
        float volume = _SFXSlider.value;
        _SFXMixer.SetFloat("SFXVol", volume);
    }

    public void FullScreen(bool fullScreen)
    {
        if (fullScreen)
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        else
            Screen.fullScreenMode = FullScreenMode.Windowed;

    }
}