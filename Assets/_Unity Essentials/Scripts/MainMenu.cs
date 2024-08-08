using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("7_BallRoll"); 
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
