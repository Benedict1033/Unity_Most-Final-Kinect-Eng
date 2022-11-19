using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider2D))]
public class DragEasy : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;

    public GameObject nextBtn;

    public static int i = 0;

    void OnMouseDown()
    {
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        if (i == 0)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        i++;
        nextBtn.SetActive(true);
        Invoke("wait", 2);
    }

    void wait() {
        SceneManager.LoadScene("5.Normal");
    }
}
