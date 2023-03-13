using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text newText;

    public GameObject newText2;
    // Start is called before the first frame update
    void Start()
    {
        TextChange();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TextChange(){
        newText.text = "SampleText";
        newText2.GetComponent<Text>().text = "SmapleText2";
    }
}
