using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Slots : MonoBehaviour
{
    public Text currentBet;
    public Text gameOutcome;
    
    public Image slot0;
    public Image slot1;
    public Image slot2;

    private List<Image> slots;
    
    public GameObject SlotsObject;
    public GameObject EndOfGame;

    public void Start()
    {
        currentBet.text = PlayerPrefs.GetInt("Bet").ToString();
    }

    public void SpinButton()
    {
        List<int> spins = new List<int>();
        Sprite[] sprites = Resources.LoadAll<Sprite>("Sprites/Slots Icon");
        
        slots = new List<Image>(){slot0,slot1,slot2};
        
        foreach (var slot in slots) //Loops through each slot and and randomises them
        {
            int spin = Random.Range(0, 9);
            spins.Add(spin);
            slot.sprite = sprites[spin];
        }

        Win(spins);
    }

    private void Win(List<int> spins)
    {
        if (spins[0] == spins[1] && spins[0] == spins[3])
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
        EndOfGame.SetActive(true);
        SlotsObject.SetActive(false);        
    }
}
