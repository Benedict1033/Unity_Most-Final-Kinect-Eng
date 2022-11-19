using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Together_Hard_Mom : MonoBehaviour
{
    public GameObject[] Btn;
    public static bool count;
    public static bool count1;
    public static int eggCount;
    public static int ovenCount;

    public GameObject[] obj;

    public Text sonText;

    private void Start()
    {
        count = false;
        count1 = false;
        eggCount = 0;
        ovenCount = 0;
    }
    public void clickW()
    {
        Together_Hard_Mom.count = true;
        if (count && count1)
        {
            
            obj[2].SetActive(true);
            sonText.text = "Parents, please click to Stirring";
        }
        else
        {
            obj[0].SetActive(true);


        }
    }

    public void clickF()
    {
        Together_Hard_Mom.count1 = true;
        if (count && count1)
        {
            sonText.text = "Parents, please click to Stirring";

            obj[2].SetActive(true);

        }
        else
        {
            obj[1].SetActive(true);
        }
    }

    public void mix()
    {
        
            Btn[0].SetActive(true);
        
    }

    public void egg()
    {
        Together_Hard_Mom.eggCount++;
        if (eggCount == 3)
        {
            Btn[0].SetActive(true);
        }
    }

    public void oven()
    {
        Together_Hard_Mom.ovenCount++;
        if (ovenCount == 3)
        {
            Btn[1].SetActive(true);
            Btn[2].SetActive(false);
        }
    }

}
