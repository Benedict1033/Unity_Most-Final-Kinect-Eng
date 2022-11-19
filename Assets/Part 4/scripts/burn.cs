using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burn : MonoBehaviour
{
    public GameObject[] meet;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("awwake", 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void awwake() {

        meet[0].gameObject.SetActive(true);
        meet[1].gameObject.SetActive(true);
        meet[2].gameObject.SetActive(true);
    }


    public void back() {

        meet[0].gameObject.SetActive(false);
        meet[1].gameObject.SetActive(false);
        meet[2].gameObject.SetActive(false);
        meet[3].gameObject.SetActive(true);
    } 
}
