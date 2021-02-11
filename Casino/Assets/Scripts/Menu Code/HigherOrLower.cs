using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class HigherOrLower : MonoBehaviour
{
    public Image leftCard;
    public Image rightCard;
    
    public Text currentBet;
    public Text gameOutcome;
    
    public GameObject HorL;
    public GameObject EndOfGame;
    
    private List<string> cardNums = new List<string>() {"A","2","3","4","5","6","7","8","9","10","J","Q","K"};
    private List<string> suits = new List<string>() {"C","D","H","S"};
    
    private List<int> cardValues = new List<int>();

    public void Start()
    {
        cardValues = new List<int>();
        DisplayCard(leftCard, GetRandomCard());
        currentBet.text = PlayerPrefs.GetInt("Bet").ToString();
    }

    private string GetRandomCard()
    {
        int cardValue;
        while (true)
        {
            cardValue = (Random.Range(0, cardNums.Count));

            if (!(cardValues.Contains(cardValue)))
            {
                Debug.Log("A");
                
                cardValues.Add(cardValue);
                foreach (var value in cardValues)
                {
                    Debug.Log(value);
                }
                break;
            }
            
            
        }
        
        return cardNums[cardValue] + suits[Random.Range(0, suits.Count)];
    }

    private void DisplayCard(Image image, string card)
    {
        image.sprite = Resources.Load <Sprite>("Sprites/Cards/" + card);
    }
    

    public void Option(string HorL)
    {
        DisplayCard(rightCard, GetRandomCard());
        if (cardValues[0]<cardValues[1] && HorL.Equals("Higher") || cardValues[0]>cardValues[1] && HorL.Equals("Lower") )
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
        HorL.SetActive(false);
        EndOfGame.SetActive(true);
    }
}
