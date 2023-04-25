using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
private bool spawned = false;

    void OnTriggerEnter2D(Collider2D other){
        if(spawned == false && other.tag == "Player"){
            Instantiate(Resources.Load<GameObject>("Octopus"), transform.position, Quaternion.identity).name = "Octopus";
            spawned = true;
        }
    }
}
