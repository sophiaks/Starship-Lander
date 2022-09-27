using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Diagnostics;
using UnityEngine.SceneManagement;
using System.Collections.Specialized;
using CodeMonkey.Utils;

public class StarshipController : MonoBehaviour
{

    [SerializeField] float trhusterForce = 72000000f;
    [SerializeField] float tiltingForce = 80f;
    [SerializeField] public int gas = 1500;
    [SerializeField] public int electricity = 10000;
    [SerializeField] public int initialXVel = 500;
    [SerializeField] public int initialYVel = -500;
    private float gasFloat;
    private float eleFloat;

    public Slider fuelSlider;
    public Slider electricitySlider;

    public float velocityX;
    public float velocityY;

    private GameObject LandingDock;
    private GameObject Pointer;
    private Vector3 tgtPos;
    private RectTransform pointerRectTransform;

    //public GameObject starship;

    bool thrust = false;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        LandingDock = GameObject.Find("Landing Dock");
        pointerRectTransform = GameObject.Find("Pointer").GetComponent<RectTransform>();
    }

    void Start(){

        rb.velocity = new Vector2(initialXVel, initialYVel);

        tgtPos = new Vector3(LandingDock.transform.position.x, LandingDock.transform.position.y);

        fuelSlider.value = gas;
        electricitySlider.value = electricity;
}

    // Update is called once per frame
    private void Update()
    {
        Vector3 tgt = tgtPos;
        Vector3 origin = new Vector3(transform.position.x, transform.position.x);
        Vector3 dir = (tgt - origin).normalized;
        float angle = UtilsClass.GetAngleFromVectorFloat(dir);
        pointerRectTransform.localEulerAngles = new Vector3(0, 0, 180+angle);

        float tilt = -Input.GetAxis("Horizontal");
        thrust = Input.GetKey(KeyCode.Space);

        if(!Mathf.Approximately(tilt, 0f) && electricity > 0){
            rb.freezeRotation = true;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + (new Vector3 (0f, 0f, tilt * tiltingForce * Time.deltaTime)));
            electricity -= 1;
            
            
            eleFloat = ((float)electricity / 10000);
            electricitySlider.value = eleFloat;

            print(electricitySlider.value);
        }

        rb.freezeRotation = false;

        

        velocityX = rb.velocity.x;
        velocityY = rb.velocity.y;

        if (transform.position.x < -6100 || transform.position.x > 6100){
            Destroy(gameObject);
            // Loads second scene (after Main Menu)
            StartCoroutine(WaitCoroutine());
            SceneManager.LoadScene(2);
        }
        
    }

    private void FixedUpdate()
    {
        if (thrust && gas > 0){
            rb.AddRelativeForce(Vector2.up * trhusterForce * Time.deltaTime);
            gas -= 1;

            gasFloat = ((float)gas / 1500);

            fuelSlider.value = gasFloat;
            print(fuelSlider.value);

        }
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (Math.Abs(velocityY) > 10)
        {
            Destroy(gameObject);
            // Loads second scene (after Main Menu)
            StartCoroutine(WaitCoroutine());
            SceneManager.LoadScene(2);
        }

    }

    IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(1);
    }
}
