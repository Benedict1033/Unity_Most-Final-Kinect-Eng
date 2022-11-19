using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Say_Normal : MonoBehaviour
{
    public static int i = 0;
    public static int j = 0;
    public GameObject next;

    private void Start()
    {
        i = 0;
        j = 0;
    }

    public void dad() {
        Say_Normal.i = 1;
        if (i == 1 && j == 1) {
            next.SetActive(true);
        }
    }

    public void mom() {
        Say_Normal.j = 1;
        if (i == 1 && j == 1)
        {
            next.SetActive(true);
        }
    }
}
