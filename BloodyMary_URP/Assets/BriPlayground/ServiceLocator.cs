using Cinemachine;
using UnityEngine;

public class ServiceLocator 
{
    //reference for all game managers this is created in the Game.cs
    public static Game _Game; 
   // public static SceneManger _SceneManger;
    public static SelectInterations _SelectInterations; 
    
    
    

    //public static MashManager _MashManager;
  

    //specific areas of the game
    
    //ref to camera & players 
    public static GameObject _Player;
    public static CinemachineBrain _PlayerCamera;
    
    
    public static CinemachineVirtualCamera _LivingRoomCamera;
    public static CinemachineVirtualCamera _ComputerCamera;
   // public static CinemachineVirtualCamera _BathroomMirrorCamera;

    public static CinemachineVirtualCamera _ExamineCamera; 
    
    //2d scenes
    public static GameObject _2DComputerImage; 
     

}
