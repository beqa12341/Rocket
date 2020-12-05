using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketShip : MonoBehaviour
{

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
        if (Input.GetKey(KeyCode.Space))
        {
            
            rigidBody.AddRelativeForce(Vector3.up*Time.deltaTime);

            if(!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }

            if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(100*Vector3.forward*Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-100 * Vector3.forward*Time.deltaTime);

        }
    }
}
