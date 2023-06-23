using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus; 

public class SceneManger : MonoBehaviour
{
    private Flowchart _flowchart; 
    
    public enum GameScenes
    {
        HappyBirthday,
        Mash,
        AolIntro,
        FirstAoLConvo,
        OuijaBoard,
        Summoning
    }

    public GameScenes currentScene;
    private GameScenes targetScene; 
    private bool changeScene = false; 
    
   //This is a prototype script when looking to refactor let's see if there's a way to make this a statemaching
   // or see if it's worth.
   //might be good to run an end state that runs a specific camera fade. 
    
    // Start is called before the first frame update
    void Start()
    {
        _flowchart = ServiceLocator._Flowchart; 
        //set the first scene
        currentScene = GameScenes.HappyBirthday; 
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    public void ChangeScene(GameScenes nextScene)
    {
        if (nextScene == GameScenes.Mash)
        {
            Debug.Log("Moving to Mash Scene");
            targetScene = GameScenes.Mash;
            _flowchart.SendFungusMessage(targetScene.ToString());
            changeScene = true;
          
        }

        if (nextScene == GameScenes.AolIntro)
        {
            Debug.Log("AOL scene started");
            targetScene = GameScenes.AolIntro;
            changeScene = true; 
            _flowchart.SendFungusMessage(targetScene.ToString());
        }

        if (nextScene == GameScenes.FirstAoLConvo)
        {
            Debug.Log("message convo started");
            targetScene = GameScenes.FirstAoLConvo;
            changeScene = true; 
            _flowchart.SendFungusMessage(targetScene.ToString());
        }

        if (nextScene == GameScenes.OuijaBoard)
        {
            
        }

        if (nextScene == GameScenes.Summoning)
        {
            Debug.Log("now entering summoning");
            //should teleport the player into the bathroom 
            ServiceLocator._Player.GetComponent<Transform>().position = new Vector3(-1.725f, 0.459f, -3.461f);
            targetScene = GameScenes.Summoning; 
            _flowchart.SendFungusMessage(targetScene.ToString());
            //might need to turn the player around to another location or grab a set location early on in the game and then just change to that transform
            // ServiceLocator._Player.GetComponent<Transform>().rotation = 
            // shut door
            //start prompt to turn off the lights 


        }
        
    }

 
    

}
