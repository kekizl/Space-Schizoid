using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    
    void OnCollisionEnter2D(Collision2D collision){
        //destroys bullet
        
        if(collision.gameObject.TryGetComponent<HealthSystem>(out HealthSystem enemyComponent)){
            enemyComponent.TakeDamage(1);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag != "Bullet"){
            Destroy(gameObject); //destroy bullet
        }
    }
}
