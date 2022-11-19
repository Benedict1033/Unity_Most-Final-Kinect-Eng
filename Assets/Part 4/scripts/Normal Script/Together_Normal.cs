using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Together_Normal : MonoBehaviour
{
    public GameObject []Btn;
    public static int sonI;

    private void Start()
    {
        sonI = 0;
    }

    public void click()
    {
        Together_Normal.sonI++;
        if (sonI == 9) {
            Btn[0].SetActive(true);
        }
    }

}
