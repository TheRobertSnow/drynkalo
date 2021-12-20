using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class MainGame : MonoBehaviour
{
    [Header("UI Text Objects")]
    public TextMeshProUGUI playerNameTxt;
    public TextMeshProUGUI cardTitleTxt;
    public TextMeshProUGUI cardDescTxt;

    [Header("Data Stuff")]
    public TextAsset jsonFile;
    public Cards cardsList = new Cards();


    private int currentPlayer = 1;
    public List<Player> players = new List<Player>();

    // Start is called before the first frame update
    void Start()
    {
        cardsList = JsonUtility.FromJson<Cards>(jsonFile.text);
        
        string tempPrefix = "Player";
        for (int i = 1; i < 9; i++)
        {
            // Get name associated with player ids
            string tempName = PlayerPrefs.GetString(tempPrefix + i.ToString());
            Debug.Log(tempName);
            // if player exists
            if (tempName != "")
            {
                // Add the player to the players list
                Player tempPlayer = new Player();
                tempPlayer.name = tempName;
                players.Add(tempPlayer);
            }
        }


        UpdateCard();
    }

    /// <summary>
    /// <c>OnCardCompleted()</c>
    /// loads next card.
    /// </summary>
    public void OnCardCompleted()
    {
        Debug.Log("Card completed");
        UpdateCard();

    }

    public void UpdateCard()
    {
        if (currentPlayer == players.Count+1)
        {
            currentPlayer = 1;
        }
        System.Random random = new System.Random();
        int index = random.Next(cardsList.cards.Length);

        playerNameTxt.text = players[currentPlayer-1].name;
        cardTitleTxt.text = cardsList.cards[index].title;
        cardDescTxt.text = cardsList.cards[index].description;

        currentPlayer++;
    }
}

[System.Serializable]
public class Cards
{
    public DrinkCard[] cards;
}

[System.Serializable]
public class DrinkCard
{
    public string cardType;
    public string title;
    public string description;
}

[System.Serializable]
public class Player
{
    public string name;
}
