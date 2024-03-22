using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D birdRigidBody;
    public float flapStrength;
    public Logic logic;
    public bool birdAlive = true;
    
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<Logic>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && birdAlive) 
        {
            birdRigidBody.velocity = Vector2.up * flapStrength;
        }

        if ((transform.position.y > 25 || transform.position.y < -25))
        {
            logic.GameOver();
            birdAlive = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        logic.GameOver();
        birdAlive = false;
    }
}
