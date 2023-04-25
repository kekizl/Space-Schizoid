using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] public float health; 
    [SerializeField] public float maxHealth = 10f;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damageAmount){
    health -= damageAmount;

    if(health <= 0){
        GetComponent<LootBag>().InstantiateLoot(transform.position);
        Destroy(gameObject);
    } 
    }

}
