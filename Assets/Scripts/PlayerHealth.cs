using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 10f;
    public float currentHealth = 10f;

    void Start(){
    }

    public void TakeDamage(float amount){
        //slider = GetComponent<Slider>();
        currentHealth -= amount;

        if(currentHealth <= 0){
            //change to gameOver menu later
            Destroy(gameObject);
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void Heal(float amount){
        if(currentHealth != maxHealth){
        currentHealth += amount;}
    }

    public void IncreaseMax(float amount){
        maxHealth += amount;
        currentHealth = maxHealth;
    }
}
