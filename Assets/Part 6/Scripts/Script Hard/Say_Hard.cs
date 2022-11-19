using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Say_Hard : MonoBehaviour
{
    public Animator anim;
    int i =0;

    public Image img;

    private void Update()
    {
        if (BodySourceViewHh.i == 1)
        {
            anim.SetBool("love", true);
            anim.StartPlayback();
        }
        else { 
            anim.StopPlayback();
        }

        if (img.fillAmount==1){
            Invoke("wait", 2);
        }
    }

    void wait() { 
            SceneManager.LoadScene("final start");

    }
}