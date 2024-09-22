using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine; 

public class CameraPriority : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera newVirtualCamera;
    [SerializeField] private GameObject oldVirtualCameraObject, newVirtualCameraObject;
    [SerializeField] private int highestPriority; //whats the highest we want to have this set
    [SerializeField] private int defaultPriority; 
    
    // Start is called before the first frame update
    void Start()
    {
        if (newVirtualCamera != null)
        {
            defaultPriority = newVirtualCamera.Priority; 
        }
    }

    public void SetCameraHighestPriority()
    {
        newVirtualCamera.Priority = highestPriority; 
        newVirtualCameraObject.SetActive(true);
        oldVirtualCameraObject.SetActive(false);
    }
  
}
