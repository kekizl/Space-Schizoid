using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerSanity : MonoBehaviour
{
    Camera m_MainCamera;


    public float maxSanity = 100f;
    public float currentSanity = 100f;
    
    void Start(){
        
        m_MainCamera = Camera.main;
    }

    //sanity debuff when it becomse too low
    public void LowerSanity(float amount){
        currentSanity -= amount;

        if(currentSanity <= 20){
            m_MainCamera.orthographicSize = 5;
        }
        else{
            m_MainCamera.orthographicSize = 10;
        }
    }

    public void RegainSanity(float amount){
        currentSanity += amount;

        if(currentSanity <= 20){
            m_MainCamera.orthographicSize = 5;
        }
        else{
            m_MainCamera.orthographicSize = 10;
        }
    }
}
