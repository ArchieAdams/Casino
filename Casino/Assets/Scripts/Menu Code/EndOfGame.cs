using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndOfGame : MonoBehaviour
{
    public Text Title;
    public Text PrizeText;
    public Text BalanceText;

    public void Start()
    {
        int bet = PlayerPrefs.GetInt("Bet");
        if (Title.text.Equals("You Win"))
        {
            FindObjectOfType<AudioManager>().Play("Correct");
            PrizeText.text = "+" + (bet*2);
            PlayerPrefs.SetInt("Balance", PlayerPrefs.GetInt(PlayerPrefs.GetString("Name") + "Balance") + bet * 2);
            BalanceText.text = "Your balance is now : " + PlayerPrefs.GetInt("Balance").ToString();
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("Incorrect");
            PrizeText.text = "-" + (bet);
            BalanceText.text = "Your balance is now : " + PlayerPrefs.GetInt(PlayerPrefs.GetString("Name") + "Balance").ToString();
        }
        PlayerPrefs.SetString("Reset", "True");
    }

    public void Reset()
    {
        SceneManager.LoadScene("Reset");
    }
}
