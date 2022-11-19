using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagment : MonoBehaviour
{
    public static int people;

   public void home()=> SceneManager.LoadScene("Home");

   public void easy()=> SceneManager.LoadScene("1.Easy");

   public void normal()=> SceneManager.LoadScene("1.Normal");

   public void hard()=> SceneManager.LoadScene("1.Puzzle");

    public void easy2() => SceneManager.LoadScene("2.Easy");

    public void normal2() => SceneManager.LoadScene("2.Normal");

    public void hard2() => SceneManager.LoadScene("2.Puzzle"); 
    
    public void easy3() => SceneManager.LoadScene("3.Easy");

    public void normal3() => SceneManager.LoadScene("3.Normal");

    public void hard3() => SceneManager.LoadScene("3.Puzzle"); 
    
    public void easy4() => SceneManager.LoadScene("4.Easy");

    public void normal4() => SceneManager.LoadScene("4.Normal");

    public void hard4() => SceneManager.LoadScene("4.Puzzle");
    
    public void easy5() => SceneManager.LoadScene("5.Easy");

    public void normal5() => SceneManager.LoadScene("5.Normal");

    public void hard5() => SceneManager.LoadScene("5.Puzzle"); 
    
    public void easy6() => SceneManager.LoadScene("6.Easy");

    public void normal6() => SceneManager.LoadScene("6.Normal");

    public void hard6() => SceneManager.LoadScene("6.Puzzle");
}
