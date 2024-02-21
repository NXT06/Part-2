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
        fixedPos.x = target.position.x;
        fixedPos.y = target.position.y;

    }

    // Update is called once per frame
    void Update()
    {
   
    }

    private void FixedUpdate()
    {
        if (targetCode == 1)
        {
            rotationSpeed += Time.deltaTime; 
            float y = Mathf.Cos(rotationSpeed) * range;
            float x = transform.position.x;
            transform.position = new Vector2(fixedPos.x, fixedPos.y + y);
           

        }
        else if (targetCode == 2)
        {
            rotationSpeed += Time.deltaTime;
            float y = Mathf.Sin(rotationSpeed) * radius;
            float x = Mathf.Cos(rotationSpeed) * radius; 
        
            transform.position = new Vector2(fixedPos.x + x, fixedPos.y + y);
        }
        else if (targetCode == 3)
        {
            rotationSpeed += Time.deltaTime;
            float x = Mathf.Cos(rotationSpeed) * range;
            float y = transform.position.y;
            transform.position = new Vector2(fixedPos.x + x, fixedPos.y);
            
        }

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {

        timerValue += 0.3f; 
        float interpolation = destroyed.Evaluate(timerValue);
        if (timerValue >= 0.9f)
        {
           
            SendMessage("Targets", 1);
            Destroy(gameObject);
        }
        transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, interpolation);


    }
}
