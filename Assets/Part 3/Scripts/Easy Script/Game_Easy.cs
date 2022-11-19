using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Easy : MonoBehaviour
{
    public Text win;
    public GameObject nextText;

    public void click() {

        transform.GetChild(0).gameObject.SetActive(true);
        Invoke("close", 0.5f);
    }

     void close() {
        if (transform.name != "月餅")
        {
            transform.GetChild(0).gameObject.SetActive(false);
            win.text = "Try Again";
        }

        else
        {
            win.text = "Click to the next Game";
            nextText.SetActive(true);
        }
    }
}
