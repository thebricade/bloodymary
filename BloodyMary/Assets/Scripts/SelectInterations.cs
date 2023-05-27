using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectInterations : MonoBehaviour
{
    public Camera playerCamera;
    private ExamineItem examineItem;
    
    
    
    //might not need below
    public Material selectedMaterial;
    public  Material baseMaterial; 
    private bool isCurrentlySelected;
    private GameObject currentlySelected;

    // Start is called before the first frame update
    void Start()
    {
        isCurrentlySelected = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Input.mousePosition);
       Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
       Debug.DrawRay(ray.origin,ray.direction *10, Color.red);
       RaycastHit hit;
       
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.CompareTag("KeyItem"))
            {
                //Get the examine item component 
                examineItem = hit.collider.gameObject.GetComponent<ExamineItem>();
                Debug.Log("Hit something");

                if (examineItem != null)
                {
                    //figure out current state and action for the item
                    switch (examineItem.currentState)
                    {
                        case ItemState.Idle:
                            Debug.Log("I hit cake");


                            examineItem.Hover();
                            break;
                        case ItemState.Hover:
                            //
                            Debug.Log("current in hover");
                            examineItem.Hover();
                            break;
                        case ItemState.Examine:
                            //
                            examineItem.Examine();
                            break;
                        case ItemState.PutDown:
                            //
                            examineItem.PutDown();
                            break;
                    }
                }
            }else if (examineItem != null)
            {
                examineItem.Idle();
                examineItem = null;
            }
        }
    }
}


/*
 * Debug.Log("hit something");
                    if (hit.collider.gameObject.CompareTag("KeyItem"))
                    {
                        Debug.Log("I hit cake");
                        Debug.DrawRay(ray.origin, ray.direction * 100, Color.green, 3f);

                        currentlySelected = hit.collider.gameObject;


                        isCurrentlySelected = true;
                        if (isCurrentlySelected)
                        {
                            baseMaterial = currentlySelected.GetComponent<MeshRenderer>().material;
                            currentlySelected.GetComponent<MeshRenderer>().material = selectedMaterial;
                        }
                    }
                    else
                    {
                        isCurrentlySelected = false;


                        if (currentlySelected != null)
                        {
                            Debug.Log(currentlySelected);
                            currentlySelected.GetComponent<MeshRenderer>().material = baseMaterial;

                        }

                    }
 */
