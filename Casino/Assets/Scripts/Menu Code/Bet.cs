using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bet : MonoBehaviour
{
    public Text currentCount;

    private int _currentBet;
    public int balance;
    
    public void ChangeBet(int bet)
    {
        if (this._currentBet + bet > 0)
        {
            this._currentBet += bet;
        }
        else
        {
            this._currentBet = 0;
        }
    }
    
    public void SetBet(int option)
    {
        if (option == -1)
        {
            
        }
    }

    private void Update()
    {
        currentCount.text = _currentBet.ToString();
    }
}
