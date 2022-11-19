using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flip : MonoBehaviour
{

    public GameObject obj;

    void Start()
    {
        Invoke("flick", 3);
    }


    void flick() {
        obj.SetActive(true);
       
    }

    public void click() {
        obj.SetActive(false);
       
    }
}
