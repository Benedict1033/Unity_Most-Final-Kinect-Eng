using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sexSelect : MonoBehaviour
{
    public int choose = 0;

    private void Start()
    {
        choose = 0;

        try
        {
            for (int i = 0; i <= 30; i++)
            {
                string str = "";

                if (PlayerPrefs.GetInt("sex" + i) == 1)
                {
                    str = "4-5 years old boy .";
                }
                else if (PlayerPrefs.GetInt("sex" + i) == 2)
                {
                    str = "5-6 years old boy .";
                }
                else if (PlayerPrefs.GetInt("sex" + i) == 3)
                {
                    str = "4-5 years old girl .";
                }  
                else if (PlayerPrefs.GetInt("sex" + i) == 4)
                {
                    str = "5-6 years old girl .";
                }

                print("i'm " + (i + 1) + " people.I'm a " + str);
            }
        }

        catch { }

    }

    public void man45()
    {
        choose = 1;
        PlayerPrefs.SetInt("sex" + SceneManagment.people, choose);
    }

    public void man56()
    {
        choose = 2;
        PlayerPrefs.SetInt("sex" + SceneManagment.people, choose);
    }

    public void women45()
    {
        choose = 3;
        PlayerPrefs.SetInt("sex" + SceneManagment.people, choose);
    }

    public void women56()
    {
        choose = 4;
        PlayerPrefs.SetInt("sex" + SceneManagment.people, choose);
    }
}
