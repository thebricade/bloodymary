using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Hertzole.GoldPlayer;
using PixelCrushers.DialogueSystem;
using UnityEngine;

public class SelectInterations : MonoBehaviour
{
    /*
    private CinemachineBrain playerCamera;
    private ExamineItemState examineItem;
    [SerializeField] private float DistanceFromObject; 
    
    
    //might not need below
    
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
       
        if (Physics.Raycast(ray, out hit, DistanceFromObject))
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
                            examineItem.Idle();
                            //examineItem.InView(objectSelecting);
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
              // ServiceLocator._Computer.GetComponent<ExamineItemState>().ChangeCondition();
               ServiceLocator._Computer.SetActive(true);
               ServiceLocator._PlayerController.GetComponent<GoldPlayerController>().Camera.LockCursor(false);
               ServiceLocator._PlayerController.SetActive(false);
               CursorOn();
               
               //ServiceLocator._Tutorial.SetActive(false);
               
               break;
           case "KEY_Magazine": 
               Debug.Log("changing view to magazine");
               ServiceLocator._Magazine.SetActive(true);
               break;
           case "KEY_Desk":
               //this case may be a little too messy and full of alt references
               Debug.Log("you are changing view to the desk");
               ServiceLocator._Desk.SetActive(true);
               //need to turn on cursor? 
               Debug.Log(ServiceLocator._PlayerController);
               ServiceLocator._PlayerController.GetComponent<GoldPlayerController>().Camera.LockCursor(false);
               CursorOn();
               ServiceLocator._PlayerController.SetActive(false);
               //need to turn off collision after so you can't restart this interaction
               GameObject keyDesk = GameObject.Find("KEY_Desk"); 
             
               keyDesk.GetComponent<MeshCollider>().enabled = false;
               keyDesk.AddComponent<ESCKey>(); 
               
               //don't forget to turn back on D: 
               
               break;
       }
    } */ 
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
