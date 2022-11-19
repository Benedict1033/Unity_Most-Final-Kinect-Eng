using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public int i = 0;

    public GameObject next;

    private void OnTriggerEnter2D(Collider2D other)
    {
        i++;
        other.gameObject.SetActive(false);
        if (i == 4) {
            next.SetActive(true);
        }
    }
}
