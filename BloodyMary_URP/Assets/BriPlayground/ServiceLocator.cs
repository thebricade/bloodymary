using Cinemachine;
using UnityEngine;

public class ServiceLocator 
{
    //reference for all game managers this is created in the Game.cs
    public static Game _Game; 
   // public static SceneManger _SceneManger; Probably will need this
    public static SelectInterations _SelectInterations; 
    
    //specific areas of the game
    
    //ref to camera & players 
    public static GameObject _Player;
    public static CinemachineBrain _PlayerCamera;
    public static GameObject _PlayerController; 
    
    public static GameObject _DialogueManager;
    public static GameObject _Computer;
    public static GameObject _Magazine;
    public static GameObject _Desk; 
    
    //Scenes
    public static GameObject _Tutorial; 
    

    public static CinemachineVirtualCamera _ExamineCamera; 
    

     

}
