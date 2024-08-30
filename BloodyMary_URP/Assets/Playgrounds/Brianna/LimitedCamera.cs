using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitedCamera : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float maxRotationAngle = 45f; 
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get mouse input for horizontal rotation
        float mouseX = Input.GetAxis("Mouse X");

        // Rotate the camera horizontally based on mouse input
        transform.Rotate(Vector3.up,  mouseX  * rotationSpeed *Time.deltaTime);

        // Optional: Limit the vertical rotation to a specific range
        float currentRotationX = transform.localEulerAngles.x;
        currentRotationX = Mathf.Clamp(currentRotationX, 0.0f, 30.0f); // Adjust the angles as needed
        transform.localEulerAngles = new Vector3(currentRotationX, transform.localEulerAngles.y, 0.0f);
    }

    
    
}
