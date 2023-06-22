using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerManager : MonoBehaviour
{
    private float timer;
    private ExamineItemState _currentComputerState; 

    public bool messageSound; 
    // Start is called before the first frame update
    void Start()
    {
        _currentComputerState = gameObject.GetComponent<ExamineItemState>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_currentComputerState.currentState);
        
        if (messageSound)
        {
            timer = timer - (1 * Time.deltaTime);
            if (timer <= 0)
            {
                LoopMessage();
            }
        }
    }

    public void LoopMessage()
    {
        timer = 30f; 
        gameObject.GetComponent<AudioSource>().Play();
        messageSound = true;
    }

    public void CurrentMessage()
    {
       //find a way to save what message you are current on here
        ServiceLocator._Flowchart.SendFungusMessage("FirstAoLConvo");
    }
}
