using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bet : MonoBehaviour
{
    public Text currentCount;
    public Text currentBalance;
    public Text remainingBalance;

    private int currentBet;
    public int balance;

    private void Start()
    {
        currentBalance.text = "Balance : " + balance;
    }

    public void ChangeBet(int bet)
    {
        if (currentBet + bet > balance)
        {
            currentBet = balance;
        }
        else if (currentBet + bet < 0)
        {
            currentBet = 0;
        }
        else
        {
            currentBet += bet;
        }
        DisplayBet();

    }
    
    public void SetBet()
    {
        currentBet = 0;
        DisplayBet();
    }
    public void BetAll()
    {
        currentBet = balance;
        DisplayBet();
    }

    private void DisplayBet()
    {
        currentCount.text = currentBet.ToString();
        Debug.Log(currentBet);
    }

    public void BetButton()
    {
        remainingBalance.text = "Your balance will be :"+(balance - currentBet);
    }
    
    public void ConfirmButton()
    {
        balance -= currentBet;
    }

}
