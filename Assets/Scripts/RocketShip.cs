using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketShip : MonoBehaviour
{
    [Range(0,10)][SerializeField] float turning = 1;
    [Range(0,5)][SerializeField] float speed = 1;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] AudioClip death;
    [SerializeField] AudioClip success;


    [SerializeField] ParticleSystem mainEngineParticles;
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem deathParticles;




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


    private void StartSuccessSequence()
    {
        state = State.Transcending;
        audioSource.Stop();
        successParticles.Play();
        audioSource.PlayOneShot(success);
        Invoke("LoadNextScene", 1f);
    }
   
    private void StartDeathSequence()
    {
        state = State.Dying;
        audioSource.Stop();
        deathParticles.Play();
        audioSource.PlayOneShot(death);
        Invoke("LoadCurrentScene", 1f);
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
            ApplyThrust();

        }

        else
        {
            audioSource.Stop();
            mainEngineParticles.Stop();

        }
    }

    private void ApplyThrust()
    {
        rigidBody.AddRelativeForce(Vector3.up * Time.deltaTime * speed);
        mainEngineParticles.Play();

        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }
    }

    private void RespondToRotateInput()
    {
        //rigidBody.freezeRotation = true;


        if (Input.GetKey(KeyCode.A))
        {
            rigidBody.AddTorque(transform.forward*Time.deltaTime*turning/10);
            
            //transform.Rotate(100 * Vector3.forward * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            rigidBody.AddTorque(-transform.forward*Time.deltaTime*turning/10);

            //transform.Rotate(-100 * Vector3.forward * Time.deltaTime);

        }

        //rigidBody.freezeRotation = false;

    }


}
    