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
    public Text coordText;

    private float velocityX = 0;
    private float velocityY = 0;

    private float coordX = 0;
    private float coordY = 0;

    private float targetX = 0;
    private float targetY = 0;

    private bool isPaused = false;

    public GameObject PausePanel;
    public GameObject LandingDock;
    
    public void Start()
    {
        
        PausePanel.gameObject.SetActive(false);
        velocityText.text = $"X: {velocityX.ToString("0")}; Y: {velocityY.ToString("0")}";
        altitudeText.text = GameObject.Find("Starship").GetComponent<StarshipController>().transform.position.y.ToString("0");

        LandingDock = GameObject.Find("Landing Dock");

        targetX = LandingDock.transform.position.x;
        targetY = LandingDock.transform.position.y;

        targetText.text = $"X: {targetX.ToString("0")}; Y: {targetY.ToString("0")}";

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

        coordX = GameObject.Find("Starship").GetComponent<StarshipController>().transform.position.x;
        coordY = GameObject.Find("Starship").GetComponent<StarshipController>().transform.position.y;

        velocityText.text = "X: " + velocityX.ToString("0") + "; " + "Y: " + velocityY.ToString("0");
        coordText.text = "X: " + coordX.ToString("0") + "; " + "Y: " + coordY.ToString("0");
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
