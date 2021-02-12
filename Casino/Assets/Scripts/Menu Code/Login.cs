using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public InputField name;
    public GameObject continueButtonObject;

    private void Start()
    {
        name.text = PlayerPrefs.GetString("Name");  //Displays the lasted logged in user
    }

    private void Update()
    {
        continueButtonObject.SetActive(name.text.Length > 0);   //Checks if you have typed anything
    }

    public void Continue()
    {
        PlayerPrefs.SetString("Name",name.text);

        if (!PlayerPrefs.HasKey(name.text + "Balance"))   //If new user sets default balance (1000)
        {
            PlayerPrefs.SetInt(name.text + "Balance", 1000);
        }
    }
}
