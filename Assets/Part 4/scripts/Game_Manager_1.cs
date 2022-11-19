
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game_Manager_1 : MonoBehaviour
{
    public GameObject thing;
    public GameObject btn;

    public GameObject flo;
    public GameObject wat;
    public GameObject tot; 
    public GameObject flo1;
    public GameObject wat1;
    public GameObject tot1;

    public GameObject []rg;
    int i = 0;
    int j = 0;

    public GameObject button;
    public GameObject button123;
    public GameObject button456;
    public GameObject button789;




   public  void starr()
    {


    Invoke("startt", 1);
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) {
            SceneManager.LoadScene("name");
        }

    }

    void startt() {

        thing.SetActive(true);
    }



    public void fall() {

        rg[i].gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
               i += 1;
        if (i == 3) {
            btn.SetActive(true);
        }
    }





    public void flour()
    {
        i += 1;

        if (i == 1)
        {
            flo.SetActive(true);
        }
        else
        {

            tot.SetActive(true);
            button.SetActive(true);
        }
    }
    public void water()
    {
        i += 1;

        if (i == 1)
        {
            wat.SetActive(true);
        }
        else
        {

            tot.SetActive(true);
            button.SetActive(true);

        }

    }

    public void flour1()
    {
        j += 1;

        if (j == 1)
        {
            flo1.SetActive(true);
        }
        else
        {

            tot1.SetActive(true);
            btn.SetActive(true);
        }
    }
    public void water1()
    {
        j += 1;

        if (j == 1)
        {
            wat1.SetActive(true);
        }
        else
        {

            tot1.SetActive(true);
            btn.SetActive(true);

        }

    }

    public void home() {

        SceneManager.LoadScene("Home");
    }

    //public void click() {
    //    uimanager.j += 1;
    //    if (uimanager.j == 9)
    //    {
    //        print(123);
    //        btn.SetActive(true);
    //    }
    //}

    //public void egg() {

    //    uimanager.k += 1;
    //    if (uimanager.k == 3) {

    //        button123.SetActive(true);
    //    }
    //}

    //public void colorr()
    //{

    //    uimanager.l += 1;
    //    if (uimanager.l == 3)
    //    {
    //        button456.SetActive(true);

    //    }
    //}

    //public void bake()
    //{

    //    uimanager.m += 1;
    //    if (uimanager.m == 3)
    //    {
    //        button789.SetActive(true);

    //    }
    //}
}
