using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using UnityEngine.Events;

public class HandleDrops : MonoBehaviour

    
{
    //handles picking up powerups and applying their effects
     void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth playerComponent)){
            //logic to pickup hearts
            if(gameObject.tag == "Heart"){
                playerComponent.Heal(1);  
            }

            //logic to pick up health buffs
            else if(gameObject.tag == "HealthUp"){
                playerComponent.GetComponent<PlayerHealth>().IncreaseMax(5);
                playerComponent.GetComponent<PlayerSanity>().LowerSanity(15);
            }

            //logic to pick up speed buffs
            else if(gameObject.tag == "Speed"){
                playerComponent.GetComponent<PlayerMovement>().moveSpeed += 3;
                playerComponent.GetComponent<PlayerSanity>().LowerSanity(15);
            }

            //logic to sanity buffs
            else if(gameObject.tag == "SanityBuff"){
                playerComponent.GetComponent<PlayerSanity>().RegainSanity(30);
                playerComponent.GetComponent<PlayerMovement>().moveSpeed -= 2;
            }
            
            Destroy(gameObject); 
        }
    }
}
