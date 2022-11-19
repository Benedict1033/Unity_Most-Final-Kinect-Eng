using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class game : MonoBehaviour
{
    public Text win;

    public void yes() {

        transform.GetChild(0).gameObject.SetActive(true);
        Invoke("close", 0.5f);
        gameObject.GetComponent<AudioSource>().Play();
    }

     void close() {
        if (transform.name != "1")
        {
            transform.GetChild(0).gameObject.SetActive(false);
            win.text = "沒關係，再一次";
        }

        else
        {
            win.text = "你好棒喔，輕點再玩一次";
            win.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }

    }
}
