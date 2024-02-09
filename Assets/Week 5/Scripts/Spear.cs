using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Spear : MonoBehaviour
{
    public new Rigidbody2D rigidBody;
    public Transform spawn;
    public float speed;
    public float maxTimer;
    float timer = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    private void FixedUpdate()
    {
        rigidBody.velocity = Vector2.right * speed;

        if (timer < maxTimer)
        {
            timer += Time.deltaTime; 
            UnityEngine.Debug.Log(timer);
        }
        else
        {
            Destroy(gameObject);
        }
  
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.SendMessage("TakeDamage", 1, SendMessageOptions.DontRequireReceiver);
        Destroy(gameObject);
    }
}
