using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Highscore : MonoBehaviour
{
    float highscore;
    float currentScore;
    public TextMeshProUGUI score; 
    // Start is called before the first frame update
    void Start()
    {
        //getting highscore and current score from previous attempts
        highscore = PlayerPrefs.GetFloat("Highscore");
        currentScore = PlayerPrefs.GetFloat("CurrentScore");
        
    }

    void Update()
    {
    
        //if current score is greater than highscore updating highscore 
        if (currentScore > highscore)
        {
            PlayerPrefs.SetFloat("Highscore", currentScore);
         
        }
        //rounding highscore to an int to be displayed on UI 
        score.text = Mathf.Round(highscore).ToString();
    }
}
