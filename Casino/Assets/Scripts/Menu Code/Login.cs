using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public InputField name;
    public GameObject continueButton;

    private void Start()
    {
        name.text = PlayerPrefs.GetString("Name");
    }

    private void Update()
    {
        continueButton.SetActive(name.text.Length > 0);
    }

    public void Continue()
    {
        PlayerPrefs.SetString("Name",name.text);

        if (!PlayerPrefs.HasKey(name.text + "Balance"))
        {
            Debug.Log("Hello");
            PlayerPrefs.SetInt(name.text + "Balance", 1000);
        }
        
    }
}
