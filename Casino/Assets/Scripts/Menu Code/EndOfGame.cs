using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndOfGame : MonoBehaviour
{
    public Text Title;
    public Text PrizeText;
    public Text BalanceText;

    public void OnStart()
    {
        int bet = PlayerPrefs.GetInt("Bet");
        if (Title.text.Contains("Win"))
        {
            PrizeText.text = "+" + (bet*2);
            PlayerPrefs.SetInt("Balance", PlayerPrefs.GetInt("Balance") + bet * 2);
            BalanceText.text = "Your balance is now : " + PlayerPrefs.GetInt("Balance").ToString();
        }
        else
        {
            PrizeText.text = "-" + (bet);
            BalanceText.text = "Your balance is now : " + PlayerPrefs.GetInt("Balance").ToString();
        }
    }
}
