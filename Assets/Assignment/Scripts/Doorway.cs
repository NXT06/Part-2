using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Doorway : MonoBehaviour
{
    public SpriteRenderer doorClosed;
    public Sprite doorOpen; 
    Rigidbody2D doorWay;
    float highscore;
    float currentScore;
    public Slider targetCounter; 
 
    // Start is called before the first frame update
    private void Start()
    {
        doorWay = GetComponent<Rigidbody2D>();
        highscore = PlayerPrefs.GetFloat("Highscore");
        currentScore = PlayerPrefs.GetFloat("CurrentScore");

    }
    private void Update()
    {
        //changing door sprite from closed to open once all targets have been destroyed
     if (targetCounter.value == 10) 
        {
            doorClosed.sprite = doorOpen;
        }
    }

    public void LoadNextScene()  //loading next scene script
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(nextSceneIndex);
        if (currentScore > highscore)
        {
            PlayerPrefs.SetFloat("Highscore", currentScore);  //updating highscore if current score is greater

        }
    }

 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (targetCounter.value == 10) //once all targets have been destroyed collision with the door loads next scene
        {
            
            LoadNextScene();
        }
    }
}
