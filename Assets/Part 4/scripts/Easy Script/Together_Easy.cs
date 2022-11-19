using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Together_Easy : MonoBehaviour
{
    public GameObject[] obj;
    public static int i = 0;
    public GameObject []Btn;

    public GameObject cutObj;

    public static int momI;

    private void Start()
    {
        i = 0;
        momI = 0;
    }


    public void click() {
        if (i <= 2)
        {
            obj[i].SetActive(true);
            i++;
        }
        else
        {
           Btn[0].SetActive(true);
        }

    }

    public void clickMom()
    {
        cutObj.GetComponent<Image>().color = new Color(255, 255, 255, 0);
        cutObj.GetComponent<Button>().enabled = false;
        cutObj.transform.GetChild(0).gameObject.SetActive(true);
        Together_Easy.momI += 1;

        if (momI == 3) {
            Btn[1].SetActive(true);
        }

    }

}
