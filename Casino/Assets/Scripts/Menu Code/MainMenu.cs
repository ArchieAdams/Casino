using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.iOS;

public class MainMenu : MonoBehaviour
{
    public AudioMixer musicMixer;
    public AudioMixer sfxMixer;

    public GameObject mainMenuObject;
    public GameObject betObject;
    
    public void Awake()
    {

        if ((PlayerPrefs.GetInt("key", -1234) == -1234)) //Checks is the current Game has saved files if not creates them
        {
            Debug.Log("Using Presets");
            PlayerPrefs.SetInt("key", 0);
            //Game Options presets
            PlayerPrefs.SetFloat("Music Volume", -16.5f);
            PlayerPrefs.SetFloat("SFX Volume", 0f);
            //Game
            PlayerPrefs.SetString("Reset", "False");
            PlayerPrefs.SetString("Name", "Archie");
        }
        
    }

    public void Start()
    {
        //Sets volume based on what you have set in the option file
        float musicVolume = PlayerPrefs.GetFloat("Music Volume");
        musicMixer.SetFloat("GameMusic", musicVolume); 
        
        float sfxVolume = PlayerPrefs.GetFloat("SFX Volume");
        sfxMixer.SetFloat("GameSFX", sfxVolume);

        if (PlayerPrefs.GetString("Reset").Equals("True")) //Used to Reset and skips Login to Bet so you don't have to login everytime;
        {
            betObject.SetActive(true);
            mainMenuObject.SetActive(false);
        }
        
        PlayerPrefs.SetString("Reset", "False");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
