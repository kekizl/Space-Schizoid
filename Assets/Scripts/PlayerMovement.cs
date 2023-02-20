using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        //used for managing input
        ProccessInputs();
        

    }
    //used for physics, called 50 times a second
    void FixedUpdate(){
       rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);//fixedDeltaTime to keep speed constant
        //Debug.Log(movement);
    }

    //to track player movement inputs
    void ProccessInputs(){

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        //movement.x = Input.GetAxisRaw("Horizontal");
        //movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }
}
