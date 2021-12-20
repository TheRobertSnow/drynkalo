using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [Header("Menus")]
    public GameObject mainMenu;
    public GameObject playersMenu;
    public GameObject namesMenu;
    public GameObject bjarniMenu;

    private int playerCounter = 1;
    private int playerCounterNumbaTwo = 1;
    [SerializeField] TextMeshProUGUI playerCounterText;
    [SerializeField] TextMeshProUGUI playerIdText;
    [SerializeField] TMP_InputField nameInputField;
    

    /// <summary>
    /// <c>OnSettingsSelected()</c>
    /// activates the settings menu.
    /// </summary>
    public void OnSettingsSelected()
    {
        mainMenu.SetActive(false);
        bjarniMenu.SetActive(true);
    }

    /// <summary>
    /// <c>OnStartSelected()</c>
    /// activates the players menu.
    /// </summary>
    public void OnStartSelected()
    {
        mainMenu.SetActive(false);
        playersMenu.SetActive(true);
    }

    /// <summary>
    /// <c>FuckGoBack()</c>
    /// reactivates the main menu.
    /// </summary>
    public void FuckGoBack()
    {
        bjarniMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    /// <summary>
    /// <c>OnIncrementBtnSelected()</c>
    /// increments the player counter.
    /// </summary>
    public void OnIncrementBtnSelected()
    {
        if (playerCounter < 8)
        {
            playerCounter++;
            UpdatePlayerCounter();
        }
    }


    /// <summary>
    /// <c>OnDecrementBtnSelected()</c>
    /// decrements the player counter.
    /// </summary>
    public void OnDecrementBtnSelected()
    {
        if (playerCounter > 1)
        {
            playerCounter--;
            UpdatePlayerCounter();
        }
    }

    /// <summary>
    /// <c>UpdatePlayerCounter()</c>
    /// updates the player counter in the UI.
    /// </summary>
    public void UpdatePlayerCounter()
    {
        playerCounterText.text = playerCounter.ToString();
    }

    /// <summary>
    /// <c>OnNamesMenuSelected()</c>
    /// activates the names menu.
    /// </summary>
    public void OnNamesMenuSelected()
    {
        playersMenu.SetActive(false);
        namesMenu.SetActive(true);
        PlayerPrefs.DeleteAll();
        playerIdText.text = playerCounterNumbaTwo.ToString();
    }

    /// <summary>
    /// <c>CommitNameToPlayer()</c>
    /// takes a name written in the input field
    /// and saves it to a certain player.
    /// </summary>
    public void CommitNameToPlayer()
    {
        string prefix = "Player";

        if (playerCounterNumbaTwo == playerCounter)
        {
            Debug.Log("Based");
            string tempString = prefix + playerCounterNumbaTwo.ToString();
            PlayerPrefs.SetString(tempString, nameInputField.text);
            PlayerPrefs.SetInt("PlayerCount", playerCounter);
            SceneManager.LoadScene(1);
        }
        else if (playerCounterNumbaTwo < playerCounter)
        {
            string tempString = prefix + playerCounterNumbaTwo.ToString();
            PlayerPrefs.SetString(tempString, nameInputField.text);
            Debug.Log("Name of " + tempString + " is " + PlayerPrefs.GetString(tempString));
            nameInputField.text = "";
            playerCounterNumbaTwo++;
            playerIdText.text = playerCounterNumbaTwo.ToString();
        }
    }
}
