using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public static SoccerPlayer SelectedPlayer { get; private set; }
    public static int score; 
    public Slider chargeSlider;
    float charge;
    float maxCharge = 5;
    public TextMeshProUGUI scoreText;
    Vector2 direction; 
    
    public static void SetSelectedPlayer(SoccerPlayer player)
    {
        if (SelectedPlayer != null)
        {
            SelectedPlayer.Selected(false);
        }
        SelectedPlayer = player;
        SelectedPlayer.Selected(true);
    }
    private void FixedUpdate()
    {
        if (direction != Vector2.zero)
        {
            SelectedPlayer.Move(direction); 
            direction = Vector2.zero;
            charge = 0;
            chargeSlider.value = 0;
        }
        scoreText.text = score.ToString();
    }
    private void Update()
    {
        if (SelectedPlayer == null) return; 

        if(Input.GetKeyDown(KeyCode.Space))
        {
            charge = 0;
            direction = Vector2.zero; 
        }
        if(Input.GetKey(KeyCode.Space))
        {
            charge += Time.deltaTime;
            charge = Mathf.Clamp(charge, 0, maxCharge);
            chargeSlider.value = charge;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            direction = ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)SelectedPlayer.transform.position).normalized * charge;
        }
    }
}
