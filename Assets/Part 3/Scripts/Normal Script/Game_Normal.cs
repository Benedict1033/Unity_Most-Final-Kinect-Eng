using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Normal : MonoBehaviour
{
    public Text win;
    public GameObject nextText;
    public static int count;

    public void click() {

        transform.GetChild(0).gameObject.SetActive(true);
        Invoke("close", 0.5f);
    }

     void close() {
        if (transform.name != "月餅"&& transform.name != "湯圓")
        {
            transform.GetChild(0).gameObject.SetActive(false);
            win.text = "Try Again";
        }

        else if(transform.name == "月餅"|| transform.name == "湯圓")
        {
            Game_Normal.count += 1;
            win.text = "You're Great";
            gameObject.GetComponent<Button>().enabled = false;
        }

        if (count == 2) {
            win.text = "Click to the next Game";
            nextText.SetActive(true);
        }
    }
}
