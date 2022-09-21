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
    public Text targetText;

    private float velocityX = 0;
    private float velocityY = 0;

    private float targetX = 0;
    private float targetY = 0;

    private bool isPaused = false;

    public GameObject PausePanel;
    public GameObject LandingCoord;
    
    public void Start()
    {
        
        PausePanel.gameObject.SetActive(false);
        targetX = GameObject.Find("Landing Dock").transform.position.x;
        targetY = GameObject.Find("Landing Dock").transform.position.y;
        velocityText.text = $"X: {velocityX.ToString("0")}; Y: {velocityY.ToString("0")}";
        targetText.text = $"X: {targetX.ToString("0")}; Y: {targetY.ToString("0")}";
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
