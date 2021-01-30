using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioMixer musicMixer;
    public AudioMixer sfxMixer;



    public void Awake()
    {

        
        if ((PlayerPrefs.GetInt("key", -1234) == -1234))
        {
            Debug.Log("Using Presets");
            PlayerPrefs.SetInt("key", 0);
            //Game Options presets
            PlayerPrefs.SetFloat("Music Volume", -16.5f);
            PlayerPrefs.SetFloat("SFX Volume", 0f);
        }
    }

    public void Start()
    {
        float musicVolume = PlayerPrefs.GetFloat("Music Volume");
        musicMixer.SetFloat("GameMusic", musicVolume);
        float sfxVolume = PlayerPrefs.GetFloat("SFX Volume");
        sfxMixer.SetFloat("GameSFX", sfxVolume);
    }
    

    public void QuitGame()
    {
        Application.Quit();
    }
}
