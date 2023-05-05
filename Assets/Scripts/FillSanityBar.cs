using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


    public class FillSanityBar : MonoBehaviour
{
    public PlayerSanity playerSanity;
    public Image fillImage;
    private Slider slider;
    
   
    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        float fillValue = playerSanity.currentSanity / playerSanity.maxSanity;
        slider.value = fillValue;
        
    }
}


