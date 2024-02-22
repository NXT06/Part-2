using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class YourScore : MonoBehaviour
{
    
   
    float currentScore;
    public TextMeshProUGUI score;
    void Start()
    {
        currentScore = PlayerPrefs.GetFloat("CurrentScore"); //getting current score of player
    }

    // Update is called once per frame
    void Update()
    {
              score.text = Mathf.Round(currentScore).ToString();  //rounding current score to be displayed in game over screen
        //PlayerPrefs.SetFloat("Highscore", 0);
    }
}

