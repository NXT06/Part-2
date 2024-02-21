using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public new Rigidbody2D bullet;
    public float speed;
    public float maxTimer = 10;
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
        if (bullet.rotation >  1)
        {
            bullet.velocity = Vector2.left * speed;
        }
        if (bullet.rotation == 0)
        {
            bullet.velocity = Vector2.right * speed;
        }
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
        Destroy(gameObject);
    }
}

