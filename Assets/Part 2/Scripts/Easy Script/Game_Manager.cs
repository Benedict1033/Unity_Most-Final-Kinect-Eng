using UnityEngine;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{
    public GameObject flyButton;
    public Animator anim;
    public static int count = 0;
    public Transform shapeContainer;
    public AudioSource winSound;
    public Text winText;
    public GameObject nextText;

    public void Start()
    {
        count = 0;
    }

    private void Update()
    {
        if (count >= 2) {
            flyButton.SetActive(true);
        }
    }

    public void clickShapeT1()
    {
        RectTransform rect = GetComponent<RectTransform>();
        rect.anchoredPosition = new Vector2(553, 100);
        Game_Manager.count += 1;
        transform.parent = shapeContainer;
    }

    public void clickShapeT2()
    {
        RectTransform rect = GetComponent<RectTransform>();
        rect.anchoredPosition = new Vector2(470, 100);
        Game_Manager.count += 1;
        transform.parent = shapeContainer;
    }

    public void clickShapeR1()
    {
        RectTransform rect = GetComponent<RectTransform>();
        rect.anchoredPosition = new Vector2(557, 20);
        Game_Manager.count += 1;
        transform.parent = shapeContainer;
    }

    public void clickShapeR2()
    {
        RectTransform rect = GetComponent<RectTransform>();
        rect.anchoredPosition = new Vector2(470, 20);
        Game_Manager.count += 1;
        transform.parent = shapeContainer;
    }

    public void clickShapeC1()
    {
        RectTransform rect = GetComponent<RectTransform>();
        rect.anchoredPosition = new Vector2(555.5f, -135.5f);
        Game_Manager.count += 1;
        transform.parent = shapeContainer;
    }

    public void clickShapeC2()
    {
        RectTransform rect = GetComponent<RectTransform>();
        rect.anchoredPosition = new Vector2(474, -135.5f);
        Game_Manager.count += 1;
        transform.parent = shapeContainer;
    }

    public void clickShapeS1()
    {
        RectTransform rect = GetComponent<RectTransform>();
        rect.anchoredPosition = new Vector2(556, -59f);
        Game_Manager.count += 1;
        transform.parent = shapeContainer;
    }

    public void clickShapeS2()
    {
        RectTransform rect = GetComponent<RectTransform>();
        rect.anchoredPosition = new Vector2(470, -59f);
        Game_Manager.count += 1;
        transform.parent = shapeContainer;
    }

    public void fly()
    {
        count = -2;
        anim.SetBool("Fly", true);
        Invoke("win", 5);
        flyButton.SetActive(false);
    }

    void win() {

        winSound.Play();
        winText.text = "Click to the next Game";
        shapeContainer.gameObject.SetActive(false);
        nextText.SetActive(true);
    }
}
