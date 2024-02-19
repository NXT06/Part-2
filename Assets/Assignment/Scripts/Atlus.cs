using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atlus : MonoBehaviour
{
    Vector2 destination;
    Vector2 movement;
    public float speed = 3;
    int bullets;
    Rigidbody2D atlasRb;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        bullets = 5;
        atlasRb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        movement = destination - (Vector2)transform.position;
        if (movement.magnitude < 0.1)
        {
            movement = Vector2.zero;

        }
        atlasRb.MovePosition(atlasRb.position + movement.normalized * speed * Time.deltaTime);
       UnityEngine.Debug.Log(movement.x);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {

            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            UnityEngine.Debug.Log(destination);
        }
       animator.SetFloat("Direction", movement.x);
        animator.SetFloat("Fire Direction", destination.x);

        if (Input.GetMouseButtonDown(1))
        {
          if (bullets > 0)
            {
                animator.SetTrigger("Fire");
                bullets--;
            }
           

        }
    }

    public void Reload()
    {
        bullets = Mathf.Clamp(0, 0, 5);
        bullets += 5;
    }
}
