using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Fungus;
using GLTF.Schema;
using UnityEngine;
using Camera = UnityEngine.Camera;

public class Game : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
       InitializeService(); 
    }

    private void InitializeService()
    {
        ServiceLocator._Game = this;
        ServiceLocator._SceneManger = gameObject.GetComponent<SceneManger>();
        ServiceLocator._SelectInterations = gameObject.GetComponent<SelectInterations>(); 
        
        //narrative
        ServiceLocator._Flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
        ServiceLocator._MashManager = GameObject.Find("Mash").GetComponent<MashManager>();
        ServiceLocator._ComputerManager = GameObject.Find("Computer").GetComponent<ComputerManager>();
        
        //Camera & Player Ref
        ServiceLocator._Player = GameObject.Find("Gold Player");
        ServiceLocator._PlayerCamera = ServiceLocator._Player.GetComponentInChildren<CinemachineVirtualCamera>();
        ServiceLocator._LivingRoomCamera = GameObject.Find("CM_LivingRoom").GetComponent<CinemachineVirtualCamera>();
        ServiceLocator._ComputerCamera = GameObject.Find("CM_computer").GetComponent<CinemachineVirtualCamera>(); 
        //bathroom mirror camera when added
        ServiceLocator._ExamineCamera = GameObject.Find("ExamineCamera").GetComponent<CinemachineVirtualCamera>(); 

    }
}
