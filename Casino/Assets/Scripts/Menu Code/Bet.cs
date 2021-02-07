using UnityEngine;
using UnityEngine.UI;

public class Bet : MonoBehaviour
{
    public Text currentCount;
    public Text currentBalance;
    public Text remainingBalance;

    private int balance;
    private int currentBet;

    public void OnStart()
    {
        balance = PlayerPrefs.GetInt("Balance");
        Debug.Log(balance);
        DisplayBalance(balance);
    }

    private void DisplayBalance(int bal)
    {
        currentBalance.text = "Balance : " + bal;
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
        remainingBalance.text = "Your balance will be : "+(balance - currentBet);
    }
    
    public void ConfirmButton()
    {
        PlayerPrefs.SetInt("Bet", currentBet);
        PlayerPrefs.SetInt("Balance", (balance-currentBet));
        new HigherOrLower().OnStart();
    } 
}
