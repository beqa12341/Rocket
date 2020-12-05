using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketShip : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rocket = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        ProcessInput(rocket);

    }

    private static void ProcessInput(Vector3 rocket)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rocket.y += 1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            print("Left");
        }

        else if (Input.GetKey(KeyCode.D))
        {
            print("Right");

        }
    }
}
