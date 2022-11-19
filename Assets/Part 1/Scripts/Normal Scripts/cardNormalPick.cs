using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cardNormalPick : MonoBehaviour
{
    public Text instructionText;
    public GameObject nextText;

    public void pick() 
    {
        GetComponent<AudioSource>().Play();

        if (transform.gameObject.name == "嫦娥")
        {
            transform.GetChild(0).gameObject.SetActive(true);
            instructionText.text = "Click to the next Game";
            nextText.SetActive(true);
        }
        else 
        { 
            transform.GetChild(0).gameObject.SetActive(true);
            instructionText.text = "Try Again";
            Invoke("closePic", 0.4f);
        }
    }

    void closePic()=>transform.GetChild(0).gameObject.SetActive(false);
    
}
