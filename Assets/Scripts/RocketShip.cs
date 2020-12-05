using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketShip : MonoBehaviour
{
    [SerializeField] float turning = 20;
    Rigidbody rigidBody;
    AudioSource audioSource;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        ProcessInput();
    }



    private void ProcessInput()
    {
        Thrust();
        Rotate();
    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {

            rigidBody.AddRelativeForce(Vector3.up * Time.deltaTime);

            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }

        else
        {
            audioSource.Stop();
        }
    }

    private void Rotate()
    {
        //rigidBody.freezeRotation = true;


        if (Input.GetKey(KeyCode.A))
        {
            rigidBody.AddTorque(transform.forward*Time.deltaTime/turning);
            
            //transform.Rotate(100 * Vector3.forward * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            rigidBody.AddTorque(-transform.forward*Time.deltaTime/turning);

            //transform.Rotate(-100 * Vector3.forward * Time.deltaTime);

        }

        //rigidBody.freezeRotation = false;

    }


}
    