using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targets : MonoBehaviour
{
   
    public AnimationCurve destroyed;
    float timerValue;
    public int targetCode;
    Vector2 fixedPos;
    public float rotationSpeed;
    public float radius;
    public float range;
    public float targets = 0;
    public Transform target;


    // Start is called before the first frame update
    void Start()
    {
        SendMessage("Targets", targets, SendMessageOptions.DontRequireReceiver);
        SendMessage("Doorways", targets, SendMessageOptions.DontRequireReceiver);
        fixedPos.x = target.position.x;     //creating fixed positions based on locations before scene runs
        fixedPos.y = target.position.y;

    }


    private void FixedUpdate()
    {
        //creating target presets that can be set through the unity interface by changing the targetCode global variable
        if (targetCode == 1)
        {
            rotationSpeed += Time.deltaTime; 
            float y = Mathf.Cos(rotationSpeed) * range; //translating the target on the y axis back and forth on a loop
            float x = transform.position.x;
            transform.position = new Vector2(fixedPos.x, fixedPos.y + y); //updating target position
           

        }
        else if (targetCode == 2)
        {
            rotationSpeed += Time.deltaTime;
            float y = Mathf.Sin(rotationSpeed) * radius;        //translating the target on both x and y axis at the same time to create circular movement 
            float x = Mathf.Cos(rotationSpeed) * radius; 
        
            transform.position = new Vector2(fixedPos.x + x, fixedPos.y + y); //updating target position
        }
        else if (targetCode == 3)
        {
            rotationSpeed += Time.deltaTime;
            float x = Mathf.Cos(rotationSpeed) * range; //translating the target on the x axis back and forth on a loop
            float y = transform.position.y;
            transform.position = new Vector2(fixedPos.x + x, fixedPos.y); //updating target position

        }

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {

        timerValue += 0.3f;  //reducing the target's scale by 1/3 everytime it is shot
        float interpolation = destroyed.Evaluate(timerValue);   //using animation curve to steady the rate of reduction
        if (timerValue >= 0.9f)
        {
           
            SendMessage("Targets", 1); //sending message to target counter slider to update how many targets are remaining 
            
            Destroy(gameObject); //destroys target after enough hits 
        }
        transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, interpolation);  //lerping the scale of the targets 


    }
}
