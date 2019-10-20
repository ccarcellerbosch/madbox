using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelBarManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI currentLevelText;
    [SerializeField]
    TextMeshProUGUI nextLevelText;
    [SerializeField]
    Image barFill;

    float maxFill = 0;

    public void Initialize(int currentLevel)
    {
        currentLevelText.text = (currentLevel+1).ToString();
        nextLevelText.text = (currentLevel+2).ToString();
        barFill.fillAmount = 0;
       
    }

    public void FillBar (float currentAmount)
    {
       
        if (maxFill == 0)
            maxFill = GameplayManager.get.levelManager.GetLevelEnd().x - GameplayManager.get.charController.transform.position.x;
        float newFillValue = Remap(currentAmount, 0, maxFill, 0, 1f);
        if (newFillValue > barFill.fillAmount)
            barFill.fillAmount = newFillValue;
        if(newFillValue >= 1f && GameplayManager.get.currentState.Equals(GameState.Playing)){
            GameplayManager.get.EndLevel(true);
        }
    }


    float Remap (float value, float from1, float to1, float from2, float to2) 
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }

}
