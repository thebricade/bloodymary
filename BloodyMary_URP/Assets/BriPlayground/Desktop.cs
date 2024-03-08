using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desktop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //check if player hits escape to exit the full computer
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ServiceLocator._Tutorial.SetActive(true);
            ServiceLocator._Computer.SetActive(false);
        }
    }
}
