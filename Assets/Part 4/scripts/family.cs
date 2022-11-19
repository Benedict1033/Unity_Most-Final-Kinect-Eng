using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class family : MonoBehaviour
{

    public static int choose=0;
    private void Start()
    {
        choose = 0;
    }

    public void mom() {
        family.choose = 1;
    }

    public void dad() {
        family.choose = 2;

    }

    public void son() {
        family.choose = 3;


    }

    public void sis() {
        family.choose = 4;

    }

    public void one()
    {
        family.choose = 1;
    }

    public void two()
    {
        family.choose = 2;

    }

    public void three()
    {
        family.choose = 3;


    }

    public void four()
    {
        family.choose = 4;

    }

    public void yes()
    {
        family.choose = 1;

    }

    public void no()
    {
        family.choose = 2;

    }

    public void oneHand()
    {
        family.choose = 1;

    }

    public void twoHand()
    {
        family.choose = 2;

    }
}
