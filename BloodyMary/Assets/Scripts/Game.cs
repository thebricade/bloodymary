using System.Collections;
using System.Collections.Generic;
using Fungus;
using GLTF.Schema;
using UnityEngine;

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
        
       

        //
    }
}
