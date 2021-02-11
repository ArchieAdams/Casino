using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Blackjack : MonoBehaviour
{

    public Text currentBet;
    public Text gameOutcome;
    
    public Text playerTotalText;
    public Text playerCards;
    public Text dealerTotalText;
    public Text dealerCards;

    public Image cardImage;
    
    public GameObject BlackJack;
    public GameObject EndOfGame;
    
    private List<string> cardNums = new List<string>() {"A","2","3","4","5","6","7","8","9","10","J","Q","K"};
    private List<int> cardPoints = new List<int>() {1,2,3,4,5,6,7,8,9,10,10,10,10};
    private List<string> suits = new List<string>() {"C","D","H","S"};

    private int playerTotal;
    private int dealerTotal;
    
    private bool playerBust;
    private bool dealerBust;
    
    private bool stood;

    public void Start()
    {
        Reset();
        Hit();
        Hit();
        currentBet.text = PlayerPrefs.GetInt("Bet").ToString();
        cardImage.sprite = Resources.Load <Sprite>("Sprites/Cards/JS");
    }

    private void Reset()
    {
        playerTotal = 0;
        dealerTotal = 0;
        playerBust = false;
        dealerBust = false;
        stood = false;
        playerCards.text = "";
        dealerCards.text = "";
        dealerTotalText.text = "Dealer is Total:";

    }

    private int GetCard()
    { 
        int cardValue = (Random.Range(0, cardNums.Count));
        return cardValue;
    }
    
    private void DisplayCard(int cardValue, Text cardList)
    {
        string card = cardNums[cardValue] + suits[Random.Range(0, suits.Count)];
        cardList.text = cardList.text + " " + card;
    }
    
    private void DisplayScore(Text totalText, int total, string name)
    {
        if (IsBust(total))
        {
            totalText.text = name + " is Bust (" + total + ")";
        }
        else
        {
            totalText.text = name + " is Total: " + total;
        }
    }

    private static bool IsBust(int total)
    {
        return total > 21;
    }

    private void GetDealerCards()
    {
        while (dealerTotal<16)
        {
            int cardValue = GetCard();
            dealerTotal += cardPoints[cardValue];
            DisplayCard(cardValue, dealerCards);
            DisplayScore(dealerTotalText, dealerTotal,"Dealer");
            dealerBust = IsBust(dealerTotal);
            if (dealerBust)
            {
                break;
            }
        }
    }
    
    public void Hit()
    {
        if (!playerBust && !stood)
        {
            int cardValue = GetCard();
            playerTotal += cardPoints[cardValue];
            DisplayCard(cardValue, playerCards);
            DisplayScore(playerTotalText, playerTotal,"Player"); 
            playerBust = IsBust(playerTotal);
        }
    }
    
    public void Stand()
    {
        stood = true;
        GetDealerCards();
        Win();
    }

    private void Win()
    {
        if (playerTotal>dealerTotal && !playerBust || dealerBust && !playerBust)
        {
            gameOutcome.text = "You Win";
        }
        else
        {
            gameOutcome.text = "You Lost";
        }
        StartCoroutine(Wait());
    }
    
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
        ShowResult();
    }

    private void ShowResult()
    {
        BlackJack.SetActive(false);
        EndOfGame.SetActive(true);
        new EndOfGame().OnStart();
    }
    
}
