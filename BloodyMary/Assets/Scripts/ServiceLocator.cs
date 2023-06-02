using Fungus;
using UnityEngine;

public class ServiceLocator 
{
    //reference for all game managers this is created in the Game.cs
    public static Game _Game; 
    public static SceneManger _SceneManger;
    public static SelectInterations _SelectInterations; 
    
    
    //narrative flowcharts
    //currently only one but just in case
    public static Flowchart _Flowchart;

    public static MashManager _MashManager;
    public static ComputerManager _ComputerManager; 

    //specific areas of the game

}
