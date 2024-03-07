using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class SelectInterations : MonoBehaviour
{
    
    private CinemachineBrain playerCamera;
    private ExamineItemState examineItem;
    
    
    
    //might not need below
    public Material selectedMaterial;
    public  Material baseMaterial; 
    private bool isCurrentlySelected;
    private GameObject currentlySelected;

    // Start is called before the first frame update
    void Start()
    {
        playerCamera = ServiceLocator._PlayerCamera; 
        Debug.Log(playerCamera);
        isCurrentlySelected = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        //Debug.Log(Input.mousePosition); /// this might not work
        Ray ray = playerCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
       Debug.DrawRay(ray.origin,ray.direction *10, Color.red);
       RaycastHit hit;
       
        if (Physics.Raycast(ray, out hit, 10))
        {
            if (hit.collider.gameObject.CompareTag("KeyItem"))
            {
                //Get the examine item component 
                examineItem = hit.collider.gameObject.GetComponent<ExamineItemState>();
                Debug.Log("Hit something");
                var objectSelecting = hit.collider.gameObject.name; 

                if (examineItem != null)
                {
                    //figure out current state and action for the item
                    switch (examineItem.currentState)
                    {
                        case ItemState.Idle:
                            
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
                        case  ItemState.ChangeView:
                            ItemChangeView(objectSelecting);
                            examineItem.InView(objectSelecting);
                            //examineItem.ChangeView(objectSelecting);
                            break;
                        case ItemState.InView:
                            examineItem.InView(objectSelecting);
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

    public void CursorOn()
    {
        Cursor.visible = true;
    }

    public void ItemChangeView(string view)
    {
       Debug.Log(view);

       switch (view)
       {
           case "KEY_ComputerMonitor":
               Debug.Log("changing view to computer view");
               break;
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
