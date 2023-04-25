using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }
    }
}
