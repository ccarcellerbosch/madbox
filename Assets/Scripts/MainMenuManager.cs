using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public void ShowMainMenu(bool show){
        gameObject.SetActive(show);
    }
}
