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
   
    // Start is called before the first frame update
    void Start()
    {
       highlight = GetComponent<SpriteRenderer>(); 
    }

    // Update is called once per frame
    void Update()
    {
      
        
    }
    private void OnMouseDown()
    {

        Selected(true);
    }
    
    void Selected(bool select)
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
}
