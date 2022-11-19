using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Together_Hard_Son : MonoBehaviour
{
    public GameObject []Btn;
    public static bool count;
    public static bool count1;
    public static int cakeCount;

    public GameObject[] obj;

    public Text sonText;

    public GameObject btnnn;

    private void Start()
    {
        count =false ;
        count1=false;
        cakeCount = 0;

    }

    public void clickW()
    {
        Together_Hard_Son.count=true;
        if (count &&count1) {
            obj[2].SetActive(true);
            sonText.text = "Kid, please click to stirring";
        }
        else
        {
            obj[0].SetActive(true);


        }
    }

    public void clickF()
    {
        Together_Hard_Son.count1=true;
        if (count && count1)
        {
            sonText.text = "Kid, please click to stirring";

            obj[2].SetActive(true);

        }
        else
        {
            obj[1].SetActive(true);
        }
    }

    public void mix() {
        
       
            Btn[0].SetActive(true);
       
    }

    public void moonCake() {
        Together_Hard_Son.cakeCount++;
        print(Together_Hard_Son.cakeCount);
        if (cakeCount == 3)
        {
           btnnn.SetActive(true);
        }
    }

}
