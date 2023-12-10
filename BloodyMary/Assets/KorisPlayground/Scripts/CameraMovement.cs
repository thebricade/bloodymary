using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    private Vector3 CameraPosition;
  //  private float CameraDiv=10;

    [Header("Camera Settings")] //adds organizational header - YES
    public float CameraSpeed;   //adds controllable attribute
    public float CameraDiv; //I don't want to hard code this number

    // Start is called before the first frame update
    void Start()
    {
            CameraPosition = this.transform.position; //gets camera position
    }

    // Update is called once per frame
    void Update()
    {
       
        //user inputs
        if (Input.GetKey(KeyCode.W))
        {
            CameraPosition.y += CameraSpeed / CameraDiv;
        }

        if (Input.GetKey(KeyCode.S))
        {
            CameraPosition.y -= CameraSpeed / CameraDiv;
        }

        if (Input.GetKey(KeyCode.A))
        {
            CameraPosition.x -= CameraSpeed / CameraDiv;
        }

        if (Input.GetKey(KeyCode.D))
        {
            CameraPosition.x += CameraSpeed / CameraDiv;
        }
 
    }
}
