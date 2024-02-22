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
    private void FixedUpdate()
    {
        //testing for direction the player is currently facing (pos/neg), and then moving bullet in that direction.
        if (bullet.rotation >  1)   
        {
            bullet.velocity = Vector2.left * speed;
        }
        if (bullet.rotation == 0)
        {
            bullet.velocity = Vector2.right * speed;
        }
        //destroying bullet after 1 second to prevent clutter in scene
        if (timer < maxTimer)
        {
            timer += Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //destroying bullet once it collides
        Destroy(gameObject);
    }
}

