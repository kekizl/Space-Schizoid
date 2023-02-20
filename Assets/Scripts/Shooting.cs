using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
   public Transform playerPos;
   public GameObject bulletPrefab;

   public float bulletForce = 8f; //shot speed
   public float delay = 2;
   //public float fireRate = something;

    // Update is called once per frame
    void Update()
    {
    
        if (Input.GetKeyDown(KeyCode.UpArrow)){
            
            Shoot(1);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow)){
           
            Shoot(2);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow)){
           
            Shoot(3);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow)){
            
            Shoot(4);
        }
    }

    void Shoot(int direction){
      
        GameObject bullet = Instantiate(bulletPrefab, playerPos.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        if (direction == 1){
        rb.AddForce((playerPos.up) * bulletForce, ForceMode2D.Impulse);
        }
        else if (direction == 2){
           rb.AddForce((-playerPos.up) * bulletForce, ForceMode2D.Impulse); 
        }
        else if (direction == 3){
           rb.AddForce((-playerPos.right) * bulletForce, ForceMode2D.Impulse); 
        }
        else if (direction == 4){
           rb.AddForce((playerPos.right) * bulletForce, ForceMode2D.Impulse); 
        }
        Object.Destroy(bullet, delay);
        //Debug.Log(playerPos.down);

    }
    
}
