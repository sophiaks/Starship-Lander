using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour
{
    StarshipController startship;
    public Text velocityText;
    public Text altitudeText;
    private float velocityX;
    private float altitude;

    void Start()
    {
        print("AAAAAAAAAAAa");
    }

    void Update()
    {
        velocityX = GameObject.Find("Starship").GetComponent<StarshipController>().velocityX;
        velocityText.text = velocityX.ToString();
        print(velocityX);
    }
}
