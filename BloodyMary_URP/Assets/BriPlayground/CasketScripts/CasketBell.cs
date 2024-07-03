using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CasketBell : MonoBehaviour
{

    private int bellCount = 0;

    public CinemachineVirtualCamera coffinCamera; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(gameObject.GetComponent<ExamineItemState>().currentState == ItemState.Hover && Input.GetKeyDown(KeyCode.E))
       {
           gameObject.GetComponent<AudioSource>().Play();
           bellCount++; 
           Debug.Log("Rung bell "+ bellCount);
       }

       if (bellCount >= 3)
       {
           // change to wake up scene
           coffinCamera.Priority = 0; 
       }
        
    }
}
