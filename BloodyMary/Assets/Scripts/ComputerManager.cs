using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerManager : MonoBehaviour
{
    public ExamineItemState _ExamineItem;
    public SceneManger _SceneManger;

    public GameObject computerScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
         if (_ExamineItem.currentState == ItemState.Examine)
        {
            computerScreen.SetActive(true);
            _SceneManger.ChangeScene(SceneManger.GameScenes.FirstAoLConvo);
            _ExamineItem.currentState = ItemState.Idle; 
        }
        */ 
    }
}
