using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLose : MonoBehaviour
{
    public void PlayAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level1");
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
