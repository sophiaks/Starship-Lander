using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Diagnostics;
using UnityEngine.SceneManagement;

public class StarshipController : MonoBehaviour
{

    [SerializeField] float trhusterForce = 72000000f;
    [SerializeField] float tiltingForce = 80f;
    [SerializeField] public int gas = 800;
    [SerializeField] public int electricity = 10000;

    public float velocityX;
    public float velocityY;

    //public GameObject starship;
    
    bool thrust = false;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start(){
        rb.velocity = new Vector2(500, -500);
    }

    // Update is called once per frame
    private void Update()
    {

        float tilt = -Input.GetAxis("Horizontal");
        thrust = Input.GetKey(KeyCode.Space);

        if(!Mathf.Approximately(tilt, 0f) && electricity > 0){
            rb.freezeRotation = true;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + (new Vector3 (0f, 0f, tilt * tiltingForce * Time.deltaTime)));
            electricity -= 1;
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
