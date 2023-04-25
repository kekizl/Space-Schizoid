using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public TMP_Text healthText;
    //private TextMeshProUGUI healthui;
    public int myhealth;
    // Start is called before the first frame update
    void Start()
    {
        //healthText = GetComponent<TMP_Text>();
        myhealth = 6;
        //healthui = healthUIPrefab;
        healthText.text = "Health: " + myhealth;
    }
    public void TextChange(){
        myhealth--;
        healthText.text = "Health: " + myhealth;  
    }
}
