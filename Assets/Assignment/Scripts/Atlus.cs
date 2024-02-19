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
    Rigidbody2D atlasRb;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
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

    }
}
