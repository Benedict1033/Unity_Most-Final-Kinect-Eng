using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(CircleCollider2D))]
public class DragHard : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;

    public GameObject nextBtn;
    public GameObject againBtn;
    public Text text;

    public static int i = 0;
    public static int j = 0;
    public static int k = 0;
    public static int count = 0;

    private void Start()
    {
        i = 0;
        j = 0;
        k = 0;
        count = 0;
    }

    void OnMouseDown()
    {
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
       
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        BodySourceViewH.i = 5;

        if (other.tag == "Dad") {
            DragHard.i += 1;
            DragHard.count++;
            Destroy(this.gameObject);
        }
        if(other.tag == "Mon"){
            DragHard.j += 1;
            DragHard.count++;
            Destroy(this.gameObject);
        }
        if (other.tag == "Son") {
            DragHard.k += 1;
            DragHard.count++;
            Destroy(this.gameObject);

        }

        if (count == 3 )
        {
            if (i == 1 && j == 1 && k == 1)
            {
                nextBtn.SetActive(true);
                text.text = "你好棒喔，輕點繼續游戲！";
                Invoke("wait", 2);
            }
            else
            {
                againBtn.SetActive(true);
                text.text = "沒關係，輕點重新游戲！";
                Invoke("wait2", 2);
            }

        }
        
    }


}
