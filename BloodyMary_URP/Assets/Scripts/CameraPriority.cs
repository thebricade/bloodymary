using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine; 

public class CameraPriority : MonoBehaviour
{
    public CinemachineBrain _cinemachineBrain; 
    [SerializeField] private CinemachineVirtualCamera newVirtualCamera, oldVirtualCamera;
    [SerializeField] private GameObject oldVirtualCameraObject, newVirtualCameraObject;
    [SerializeField] private int highestPriority; //whats the highest we want to have this set
    [SerializeField] private int defaultPriority; 
    
    private CinemachineBlendDefinition easeBlend;
    private CinemachineBlendDefinition cutBlend;
    
    private void Awake()
    {
        // Define the cut blend
        cutBlend = new CinemachineBlendDefinition
        {
            m_Style = CinemachineBlendDefinition.Style.Cut,
            m_Time = 0f
        };

        // Define the ease blend
        easeBlend = new CinemachineBlendDefinition
        {
            m_Style = CinemachineBlendDefinition.Style.EaseInOut,
            m_Time = 2f
        };
    }
    
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

    public void ChangeCameraBlendEase()
    {
        _cinemachineBrain.m_DefaultBlend = easeBlend;

    }

    public void ChangeCameraBlendCut()
    {
        _cinemachineBrain.m_DefaultBlend = cutBlend;
    }
    
    private void SwitchToPerspective()
    {
       
        //vcam.m_Lens.Orthographic = false;

    }
    
    public void SetCameraBlend()
    {
        
        newVirtualCamera.Priority = highestPriority;
        oldVirtualCamera.Priority = 0; 


    }
  
}
