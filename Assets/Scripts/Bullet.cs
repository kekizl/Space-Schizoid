using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    //public UnityEvent onPlayerDamage;
    

    
    void OnCollisionEnter2D(Collision2D collision){
        //destroys bullet
        
        if(collision.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth playerComponent)){
            playerComponent.TakeDamage(1);
            //onPlayerDamage.Invoke();
            Destroy(gameObject);
        }
        else if(collision.gameObject.TryGetComponent<HealthSystem>(out HealthSystem enemyComponent)){
            enemyComponent.TakeDamage(1);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag != "Bullet"){
            Destroy(gameObject); //destroy bullet
        }
    }
}
