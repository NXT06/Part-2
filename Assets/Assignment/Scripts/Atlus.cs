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
            movement = destination - (Vector2)transform.position;       //assigning movement to the most recent mouse input
            if (movement.magnitude < 0.1)
            {
                movement = Vector2.zero;    //stops all movement once it slows down enough

            }
            atlasRb.MovePosition(atlasRb.position + movement.normalized * speed * Time.deltaTime);  //translating atlas to mouse input position based of speed
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())     //testing if mouse input was over UI or not 
            {

                destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);  //assigning destination to current mouse input
                
            }
            animator.SetFloat("Direction", movement.x);  //telling animator what direction atlus is facing 
        

        if (Input.GetMouseButtonDown(1))   //right-clcik activates shooting 
        {
            Fire();  
        }
    }

    private void Reload()       //using send message to tell UI when ammo has been refilled 
    {
        bullets = Mathf.Clamp(0, 0, 5);  //setting max bullet rounds to 5
        bullets += 5;
        SendMessage("Bullets", 5);
    }

    public void Fire()  
    {
        if (bullets > 0)  //only fires if there are bullets remaining 
        {
            animator.SetTrigger("Fire");  //telling animator when to show animation
            bullets--;
            SendMessage("Bullets", -1);  //telling UI bullets have decreased by 1
            
            //instantiating bullets depending on the position of Atlas's gun, spawns differently for left vs right based on movement 
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
  
    
    private void OnCollisionEnter2D(Collision2D collision)  //creating a collider to prevent Atlas from touching the lasers, resets player position to (0,0). 
    {
        Debug.Log("hit");
        pos.transform.position = new Vector2(0, 0);
        destination = Vector2.zero; //stopping all current movements 
    }
}
