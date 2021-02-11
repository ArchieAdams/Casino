using UnityEngine;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public AudioMixer musicMixer;
    public AudioMixer sfxMixer;

    public void Awake()
    {
        //PlayerPrefs.DeleteAll();
        if ((PlayerPrefs.GetInt("key", -1234) == -1234))
        {
            
            Debug.Log("Using Presets");
            PlayerPrefs.SetInt("key", 0);
            //Game Options presets
            PlayerPrefs.SetFloat("Music Volume", -16.5f);
            PlayerPrefs.SetFloat("SFX Volume", 0f);
            PlayerPrefs.SetString("Name", "Archie");
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
