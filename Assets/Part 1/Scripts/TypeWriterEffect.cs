using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TypeWriterEffect : MonoBehaviour
{
    public float delay = 0.1f;
    public string fullText;
    public string currentText = "";
    public Text textShow;
    public GameObject [] nextText;

    private void Start() => StartCoroutine(ShowText());

    IEnumerator ShowText()
    {
        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            textShow.text = currentText;
            yield return new WaitForSeconds(delay);

            if (i == fullText.Length)
            {
                Invoke("wait", 1);
            }
        }
    }

    void wait() {
        nextText[0].SetActive(true);
        nextText[1].SetActive(false);
    }
}
