using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void PlayAgain()
    {
        Debug.Log("Start");
        SceneManager.LoadScene(1);
    }

    public void QuitGameAgain()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
