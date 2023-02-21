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

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null)
            {
                Debug.Log("hit something");
                if (hit.collider.gameObject.CompareTag("KeyItem"))
                {
                    Debug.Log("I hit cake");
                }
            }
        }
    }
}

