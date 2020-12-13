using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscilator : MonoBehaviour
{

    [SerializeField] Vector3 movementVector = new Vector3(10f, 10f, 10f);
    [SerializeField] float speed = 2;

    float movementFactor;
    Vector3 startingPos;

    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        movementFactor = (Mathf.Sin(Time.time * speed));

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;
    }
}