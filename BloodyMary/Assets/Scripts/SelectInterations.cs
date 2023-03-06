using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectInterations : MonoBehaviour
{
    public Camera playerCamera;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Input.mousePosition);
       Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
       RaycastHit hit;

        //Debug.DrawLine(transform.position, transform.forward, Color.green);

        if (Physics.Raycast(ray, out hit))
        {
            Debug.DrawRay(ray.origin, ray.direction, Color.blue);
            if (hit.collider != null)
            {
                Debug.Log("hit something");
                if (hit.collider.gameObject.CompareTag("KeyItem"))
                {
                    Debug.Log("I hit cake");
                    Debug.DrawRay(ray.origin, ray.direction * 100, Color.green, 3f);
                    
                }
                else
                {
                  
                
                }
            }
        }
    }
}

