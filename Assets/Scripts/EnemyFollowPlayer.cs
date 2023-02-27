using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1.5f;
    Rigidbody2D rb;
    Transform target;

    Vector2 moveDirection;
    // Start is called before the first frame update

    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        target = GameObject.Find("Player").transform;   
    }

    // Update is called once per frame
    void Update()
    {
        if(target){
            //gives direction which we need to go into
            Vector3 direction = (target.position - transform.position).normalized;
            moveDirection = direction;
        }
    }
    
    void FixedUpdate(){
        if(target){
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }
    }
}
