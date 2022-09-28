using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverTutorial : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadScene(3);
    }

    public void QuitGameAgain()
    {

        SceneManager.LoadScene(0);
    }
}
