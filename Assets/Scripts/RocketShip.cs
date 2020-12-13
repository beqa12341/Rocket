using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketShip : MonoBehaviour
{
    [SerializeField] float turning = 20;
    [Range(0,5)][SerializeField] float speed = 1;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] AudioClip death;
    [SerializeField] AudioClip success;


    Rigidbody rigidBody;
    AudioSource audioSource;

    enum State
    {
        Alive, Dying, Transcending
    }

    State state = State.Alive;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

    }

    void Update()
    {
        ProcessInput();
    }

    void OnCollisionEnter(Collision collision)
    {
        if(state != State.Alive) { return; }

        switch(collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Friendly");
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            default:
                StartDeathSequence();
                break;
        }
    }

    private void StartDeathSequence()
    {
        state = State.Dying;
        audioSource.Stop();
        audioSource.PlayOneShot(death);
        Invoke("LoadCurrentScene", 1f);
    }

    private void StartSuccessSequence()
    {
        state = State.Transcending;
        audioSource.Stop();
        audioSource.PlayOneShot(success);
        Invoke("LoadNextScene", 1f);
    }

    private void LoadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    private void ProcessInput()
    {
        if(state==State.Alive)
        {
            RespondToThrustInput();
            RespondToRotateInput();
        }
    }

    private void RespondToThrustInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {

            rigidBody.AddRelativeForce(Vector3.up * Time.deltaTime*speed);

            if (!audioSource.isPlaying )
            {
                audioSource.PlayOneShot(mainEngine);
            }
        }

        else
        {
            audioSource.Stop();
        }
    }

    private void RespondToRotateInput()
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
    