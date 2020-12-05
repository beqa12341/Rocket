using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSc : MonoBehaviour
{

    RocketShip ship;
    [SerializeField] float locationY = 5;
    [SerializeField] float cameraTimeDelay;

    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        ship = FindObjectOfType<RocketShip>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameralocXY = new Vector3(ship.transform.position.x, ship.transform.position.y+locationY, transform.position.z);

        transform.position = Vector3.SmoothDamp(transform.position, cameralocXY, ref velocity, cameraTimeDelay);
        


    }
}
