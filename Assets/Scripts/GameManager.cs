using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class GameManager : MonoBehaviour
{
    StarshipController startship;
    public Text velocityText;
    public Text altitudeText;

    private float velocityX = 0;
    private float velocityY = 0;

    private bool isPaused = false;

    public GameObject PausePanel;
    
    public void Start()
    {
        PausePanel.gameObject.SetActive(false);
        velocityText.text = $"X: {velocityX.ToString("0")}; Y: {velocityY.ToString("0")}";
        altitudeText.text = GameObject.Find("Starship").GetComponent<StarshipController>().transform.position.y.ToString("0");
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused) {
                pause();
            }
            else { 
                resume(); 
            }
            
        }

        velocityX = GameObject.Find("Starship").GetComponent<StarshipController>().velocityX;
        velocityY = GameObject.Find("Starship").GetComponent<StarshipController>().velocityY;

        velocityText.text = "X: " + velocityX.ToString("0") + "; " + "Y: " + velocityY.ToString("0");
        altitudeText.text = GameObject.Find("Starship").GetComponent<StarshipController>().transform.position.y.ToString("0");
    }

    public void pause()
    {
        Time.timeScale = 0;
        PausePanel.gameObject.SetActive(true);
        isPaused = true;
    }

    public void resume()
    {
        Time.timeScale = 1;
        PausePanel.gameObject.SetActive(false);
        isPaused = false;
}


}
