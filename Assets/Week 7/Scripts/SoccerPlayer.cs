using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerPlayer : MonoBehaviour
{
    bool selected;
    SpriteRenderer highlight;
    public Color color1; 
    public Color color2;
    Rigidbody2D rb;
    public float speed = 1000; 
   
    // Start is called before the first frame update
    void Start()
    {
       highlight = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        Selected(false); 
    }

    // Update is called once per frame
    void Update()
    {
      
        
    }
    private void OnMouseDown()
    {

        Controller.SetSelectedPlayer(this);
    }
    
    public void Selected(bool select)
    {
        if (select)
        {
            highlight.color = color2;
        }
        else
        {
            highlight.color = color1;
        }
    }
    public void Move(Vector2 direction)
    {
        rb.AddForce(direction * speed);
    }
   
}
