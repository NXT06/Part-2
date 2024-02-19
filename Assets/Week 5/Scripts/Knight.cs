using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Knight : MonoBehaviour
{
    Vector2 destination;
    Vector2 movement;
    public float speed = 3;
    Rigidbody2D rb;
    Animator animator;
    bool clickOnSelf = false;
    public float health;
    public float maxHealth = 5;
    public HealthBar healthBar;
    bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
       
        health = PlayerPrefs.GetFloat("HealthSave", 5);
        SendMessage("CurrentHP", health, SendMessageOptions.DontRequireReceiver);
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        if (health < 1)
        {
            //die
            isDead = true;
            animator.SetTrigger("Death");
        }
    }

    private void FixedUpdate()
    {
        if (isDead) return;
        movement = destination - (Vector2)transform.position;

        if (movement.magnitude < 0.1)
        {
            movement = Vector2.zero;
            UnityEngine.Debug.Log(movement);
        }
        rb.MovePosition(rb.position + movement.normalized * speed * Time.deltaTime);
        
    }
    // Update is called once per frame
    void Update()
    {
        if (isDead) return;
        if (Input.GetMouseButtonDown(0) && !clickOnSelf && !EventSystem.current.IsPointerOverGameObject())
        {
            
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        animator.SetFloat("Movement", movement.magnitude);

        if(Input.GetMouseButtonDown(1))
        {
            UnityEngine.Debug.Log("click");
            animator.SetTrigger("Attack");
        }

    }
    private void OnMouseDown()
    {
        if (isDead) return;
        clickOnSelf = true;
        SendMessage("TakeDamage", 1);
  
    }
    private void OnMouseUp()
    {
        clickOnSelf = false; 
    }
    public void TakeDamage(float damage)
    {

        health = Mathf.Clamp(health, 0, maxHealth);
        health -= damage;
        PlayerPrefs.SetFloat("HealthSave", health);
        if (health < 1)
        {
            //die
            isDead = true;
            animator.SetTrigger("Death"); 
        }
        else
        {
            isDead = false;
            animator.SetTrigger("TakeDamage");
            
        }
        

    }

}
