using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atlus : MonoBehaviour
{
    Vector2 destination;
    public Vector2 movement;
    public Transform pos; 
    public float speed = 3;
    float bullets;
    Rigidbody2D atlasRb;
    Animator animator;
    public Transform spawnL;
    public Transform spawnR;
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        bullets = 5;
        atlasRb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        SendMessage("Bullets", bullets, SendMessageOptions.DontRequireReceiver);
     
    }
    private void FixedUpdate()
    {

        
            movement = destination - (Vector2)transform.position;
            if (movement.magnitude < 0.1)
            {
                movement = Vector2.zero;

            }
            atlasRb.MovePosition(atlasRb.position + movement.normalized * speed * Time.deltaTime);
        
    }

    // Update is called once per frame
    void Update()
    {

        
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {

                destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                
            }
            animator.SetFloat("Direction", movement.x);
        

        if (Input.GetMouseButtonDown(1))
        {
            Fire();
        }
    }

    private void Reload()
    {
        bullets = Mathf.Clamp(0, 0, 5);
        bullets += 5;
        SendMessage("Bullets", 5);
    }

    public void Fire()
    {
        if (bullets > 0)
        {
            animator.SetTrigger("Fire");
            bullets--;
            SendMessage("Bullets", -1);
            
            if (movement.x > 0.1)
            {
                Instantiate(bulletPrefab, spawnR.position, spawnR.rotation);
            }
            if (movement.x < 0.1) 
            {
                Instantiate(bulletPrefab, spawnL.position, spawnL.rotation);
            }
        }
    }
  public void Boundaries(bool CanMove)
    {
        if (CanMove)
        {
            Debug.Log("yes");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hit");
        pos.transform.position = new Vector2(0, 0);
        destination = Vector2.zero;
    }
}
