using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Hard : MonoBehaviour
{
    public Text win;
    public GameObject nextText;
    public static int count;

    public void click() {

        transform.GetChild(0).gameObject.SetActive(true);
        Invoke("close", 0.5f);
    }

     void close() {
        if (transform.name != "柚子")
        {
            transform.GetChild(0).gameObject.SetActive(false);
            win.text = "Try Again";
        }

        else 
        {
            Game_Normal.count += 1;
            win.text = "Click to the next Game";
            gameObject.GetComponent<Button>().enabled = false;
            nextText.gameObject.SetActive(true);
        }
    }
}
