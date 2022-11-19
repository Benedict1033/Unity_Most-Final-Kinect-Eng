using System.Collections;
using UnityEngine;

public class TextAnimation : MonoBehaviour
{
    void Start()=> StartCoroutine(anim());
    
    IEnumerator anim()
    {
        for (float i = 0.25f; i >= 0.235f; i-=0.001f)
        {
            transform.localScale = new Vector3(i,i,i);
            yield return new WaitForSeconds(0.05f);
        }
        for (float j = 0.235f; j <= 0.25f; j += 0.001f)
        {
            transform.localScale = new Vector3(j, j, j);
            yield return new WaitForSeconds(0.05f);
        }

        StartCoroutine(anim());
    }
}
