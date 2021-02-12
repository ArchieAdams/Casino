using System;
using UnityEngine;
using UnityEngine.UI;

public class Bet : MonoBehaviour
{
    public Text currentCount;
    public Text currentBalance;
    public Text remainingBalance;

    private int balance;
    private int currentBet;

    public GameObject betButtonObject;

    public void Start()
    {
        balance = PlayerPrefs.GetInt(PlayerPrefs.GetString("Name") + "Balance");
        if (balance == 0)
        {
            Application.Quit(); //Quits if you have no money
        }
        DisplayBalance(balance);
    }

    private void Update()
    {
        betButtonObject.SetActive(currentBet != 0); //Stops you betting 0 by only showing the button if you have bet money
    }

    private void DisplayBalance(int bal)
    {
        currentBalance.text = "Balance : " + bal;
    }
    

    public void ChangeBet(int bet)
    {
        if (currentBet + bet > balance) //Stops you going over your balance
        {
            currentBet = balance;
        }
        else if (currentBet + bet < 0) //Stops you going below 0
        {
            currentBet = 0;
        }
        else
        {
            currentBet += bet; //Adds to bet
        }
        DisplayBet();

    }
    
    public void SetBet()  //Set bet to 0
    {
        currentBet = 0;
        DisplayBet();
    }
    
    public void BetAll()  //Set bet to balance
    {
        currentBet = balance;
        DisplayBet();
    }

    private void DisplayBet()
    {
        currentCount.text = currentBet.ToString();
    }

    public void BetButton()   //Shows what your balance will be if you lose
    {
        remainingBalance.text = "Your balance will be : "+(balance - currentBet);
    }
    
    public void ConfirmButton()  //Saves your balance and bet
    {
        PlayerPrefs.SetInt("Bet", currentBet);
        PlayerPrefs.SetInt(PlayerPrefs.GetString("Name") + "Balance", (balance-currentBet));
        
    } 
}
