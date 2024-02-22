using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    float currentScore;
    
    
    float timer = 120;
    public TextMeshProUGUI countDown;
    private void FixedUpdate()
    {
        timer -= Time.deltaTime;  //basic timer counting down from 2 minutes
        
        countDown.text = Mathf.Round(timer).ToString();  //displaying timer in UI 

        PlayerPrefs.SetFloat("CurrentScore", timer);
        
        //Debug.Log(timer); 
        if (timer < 0f)     //if timer reaches 0 forces player to next scene
        {
            LoadNextScene();
        }
    }
    public void LoadNextScene()   //load next scene function
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(nextSceneIndex);
        
    }
}
