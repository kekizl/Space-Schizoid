using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 10f;
    public float currentHealth = 10f;
    [SerializeField] private Slider slider;
    
    void Awake(){
        //slider = GetComponent<Slider>();
        //float fillValue = currentHealth / maxHealth;
        //slider.value = fillValue;
    }
    public void TakeDamage(float amount){
        //slider = GetComponent<Slider>();
        currentHealth -= amount;

        //float fillValue = currentHealth / maxHealth;
        //slider.value = fillValue;

        if(currentHealth <= 0){
            //change to gameOver menu later
            Destroy(gameObject);
            SceneManager.LoadScene("MainMenu");
        }
    }
}
