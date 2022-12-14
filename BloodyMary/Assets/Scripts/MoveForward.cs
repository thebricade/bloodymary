using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed;
    public int zoneNumber; 

    // Start is called before the first frame update
    void Start()
    {
         Debug.Log("I called Start");
         zoneNumber = 0; 

    }

    // Update is called once per frame
    void Update()
    {
        //horizontalInput = Input.GetAxis("Horizontal");
        //transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
       Debug.Log("I hit something");
 
        if (other.gameObject.CompareTag("Car"))
        {
            Debug.Log("I hit a car");
            //subtract one from the total lives 
            //run a check to see if lives are equal to 0 
        }

        if (other.gameObject.CompareTag("Zone"))
        {
            zoneNumber += 1; 
            Debug.Log("current zone "+ zoneNumber);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
       
    }
}
