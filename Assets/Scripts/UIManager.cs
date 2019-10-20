using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Panel references")]
    [SerializeField]
    MainMenuManager mainMenu;
    [SerializeField]
    GameObject winMenu;
    [SerializeField]
    GameObject loseMenu;


    public void ShowMainMenu(bool show)
    {
        mainMenu.gameObject.SetActive(show);
    }

    public void OnPlayButtonClick()
    {
        ShowMainMenu(false);
        GameplayManager.get.StartLevel();
    }

    public void ShowFinalResults(bool win)
    {
        if (win)
            winMenu.SetActive(true);
        else
            loseMenu.SetActive(true);
    }



}
