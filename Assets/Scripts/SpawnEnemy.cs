using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
private bool spawned = false;

    void OnTriggerEnter2D(Collider2D other){
        if(spawned == false && other.tag == "Player"){
            int randomNum = Random.Range(1, 4);
            Debug.Log(randomNum);
            switch (randomNum){
                case 1:
                    Instantiate(Resources.Load<GameObject>("Octopus"), transform.position, Quaternion.identity).name = "Octopus";
                    break;
                case 2:
                    Instantiate(Resources.Load<GameObject>("Gorilla"), transform.position, Quaternion.identity).name = "Gorilla";
                    break;
                case 3:
                    Instantiate(Resources.Load<GameObject>("Griffith"), transform.position, Quaternion.identity).name = "Griffith";
                    break;
            }
            spawned = true;
        }
    }
}
