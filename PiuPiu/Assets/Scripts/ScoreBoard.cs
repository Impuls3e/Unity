using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreBoard : MonoBehaviour
{

    int score;
    string x = "SCORE:";
   
    TMP_Text scoreText;
    private void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = "SCORE:0";
    }
    public void IncreaseScore(int amountToIncrease)
    {
        score += amountToIncrease;
        string y = x + score;
        scoreText.text = y.ToString();
        

    }
}
