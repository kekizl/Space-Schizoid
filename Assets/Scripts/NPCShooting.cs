using UnityEngine;

public class NPCShooting : MonoBehaviour
{
   public Transform npcPos;
   public GameObject bulletPrefab;

   public float bulletForce = 8f; //shot speed
   public float delay = 2;
   public float fireRate = 1f;
   public float nextFire = 0;

   
   //public float fireRate = something;

    // Update is called once per frame
    void Update()
    {
        
        NPCShoot();
        
       
    }

//CAN CHANGE AFTER
    void NPCShoot(){

        if(Time.time > nextFire){

            GameObject bullet = Instantiate(bulletPrefab, npcPos.position, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());

            GameObject bullet2 = Instantiate(bulletPrefab, npcPos.position, Quaternion.identity);
            Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
            Physics2D.IgnoreCollision(bullet2.GetComponent<Collider2D>(), GetComponent<Collider2D>());

            GameObject bullet3 = Instantiate(bulletPrefab, npcPos.position, Quaternion.identity);
            Rigidbody2D rb3 = bullet3.GetComponent<Rigidbody2D>();
            Physics2D.IgnoreCollision(bullet3.GetComponent<Collider2D>(), GetComponent<Collider2D>());

            GameObject bullet4 = Instantiate(bulletPrefab, npcPos.position, Quaternion.identity);
            Rigidbody2D rb4 = bullet4.GetComponent<Rigidbody2D>();
            Physics2D.IgnoreCollision(bullet4.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            
            rb.AddForce((npcPos.up) * bulletForce, ForceMode2D.Impulse);
            
            rb2.AddForce((-npcPos.up) * bulletForce, ForceMode2D.Impulse); 
            
            rb3.AddForce((-npcPos.right) * bulletForce, ForceMode2D.Impulse); 
            
            rb4.AddForce((npcPos.right) * bulletForce, ForceMode2D.Impulse); 
            
            Object.Destroy(bullet, delay);
            Object.Destroy(bullet2, delay);
            Object.Destroy(bullet3, delay);
            Object.Destroy(bullet4, delay);


            nextFire = Time.time + fireRate;
        //Debug.Log(playerPos.down);
        }
    }
    
}
