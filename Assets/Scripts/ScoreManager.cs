using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int currentScore = 0;
    public int currentCoins = 0;
    public int maxScore = 0;

    void Start()
    {
        maxScore = PlayerPrefs.GetInt("MaxScore",0);
    }



    public void UpdateMaxScore(){
        if(currentScore > maxScore)
        {
            maxScore = currentScore;
            PlayerPrefs.SetInt("MaxScore",maxScore);
        }
    }
}
