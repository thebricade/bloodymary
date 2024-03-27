using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;


public class Game : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private CinemachineBrain cameraBrain;

    [SerializeField] private GameObject dialogueManager;
    [SerializeField] private GameObject computer;
    [SerializeField] private GameObject tutorial;

    [SerializeField] private GameObject magazine; 
    
    // Start is called before the first frame update
    void Awake()
    {
       InitializeService(); 
    }

    void Start()
    {
      //  SetUpGameStart();
    }

    private void InitializeService()
    {
        
        ServiceLocator._Game = this;
       
        
        //ServiceLocator._SceneManger = gameObject.GetComponent<SceneManger>();
        ServiceLocator._SelectInterations = gameObject.GetComponent<SelectInterations>(); 
        
        
        //narrative
        ServiceLocator._DialogueManager = dialogueManager;
        ServiceLocator._Tutorial = tutorial;
        ServiceLocator._Magazine = magazine; 
        
         
        
        //Camera & Player Ref
        ServiceLocator._Player = player;
        ServiceLocator._PlayerCamera = cameraBrain;
        ServiceLocator._Computer = computer; 
        
        
        //ServiceLocator._LivingRoomCamera = GameObject.Find("CM_LivingRoom").GetComponent<CinemachineVirtualCamera>();
        //ServiceLocator._ComputerCamera = GameObject.Find("CM_Computer").GetComponent<CinemachineVirtualCamera>(); 
        //bathroom mirror camera when added
        //ServiceLocator._ExamineCamera = GameObject.Find("ExamineCamera").GetComponent<CinemachineVirtualCamera>();
        
        //2d Game scenes 
        //ServiceLocator._2DComputerImage = GameObject.Find("ComputerImage"); 
        

    }

    private void SetUpGameStart()
    {
        /*
        //when the game starts set camera priority 
        //priority should go to CMLivingRoom
        
        //make is so that the goldplayer is turned off 
        ServiceLocator._Player.SetActive(false);
        ServiceLocator._2DComputerImage.SetActive(false);
        */ 
    }
    
    
    public void turnOnCursor()
    {
        //This can be called from fungus or when about to run something that needs a specific cursor
        //adjust this to allow an input to help us know what cursor to display
     // Cursor.visible = true;
      //Screen.lockCursor = false;  
    }

    public void ChangeCursor(string cursorType)
    {
        /*
        switch (cursorType)
        {
            case "off":
                Cursor.visible = false;
                Screen.lockCursor = true; 
                break;
            case "on":
                Cursor.visible = true;
                Screen.lockCursor = false; 
                break;
            case "mouse":
                break;
            case "pen":
                break;
        }
        */ 
    }
}
