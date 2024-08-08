using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{

    public void QuitApplication()
    {
        Application.Quit();
    }

    public void ResumeGame()
    {
        GameManager.instance.ResumeGame();
    }
}
