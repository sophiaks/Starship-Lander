using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Diagnostics;

public class StarshipController : MonoBehaviour
{

    [SerializeField] float trhusterForce = 5000f;
    [SerializeField] float tiltingForce = 60f;

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
        rb.velocity = new Vector2(100, -100);
    }

    // Update is called once per frame
    private void Update()
    {

        float tilt = Input.GetAxis("Horizontal");
        thrust = Input.GetKey(KeyCode.Space);

        if(!Mathf.Approximately(tilt, 0f)){
            rb.freezeRotation = true;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + (new Vector3 (0f, 0f, tilt * tiltingForce * Time.deltaTime)));
        }

        rb.freezeRotation = false;

        
        velocityX = rb.velocity.x;
        velocityY = rb.velocity.y;
        
    }

    private void FixedUpdate()
    {
        if (thrust){
            rb.AddRelativeForce(Vector2.up * trhusterForce * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (Math.Abs(velocityY) > 50)
        {
            Destroy(gameObject);
            // Loads second scene (after Main Menu)
            StartCoroutine(WaitCoroutine());
            Application.LoadLevel(1);
        }

    }

    IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(1);
    }
}
