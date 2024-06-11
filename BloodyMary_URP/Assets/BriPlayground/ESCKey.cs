using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hertzole.GoldPlayer;
using Unity.VisualScripting;

public class ESCKey : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //check if player hits escape to exit the full computer
        //we need to add in other objects to this script
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitLastOpened(this.gameObject);
            ServiceLocator._Tutorial.SetActive(true);
            ServiceLocator._Computer.SetActive(false);
        }
    }

    private void ExitLastOpened(GameObject sceneConnectTo)
    {
        switch (sceneConnectTo.name)
        {
            case "-Magazine-":
                Debug.Log("trying to exit Magazine");
                break;
            case "KEY_Desk":
                Debug.Log("trying to exit desk");
                //turn back on Desk stuff, also need to clean up this interaction
                ServiceLocator._Desk.SetActive(false);
                //need to turn on cursor? 
                Debug.Log(ServiceLocator._PlayerController);
                ServiceLocator._PlayerController.GetComponent<GoldPlayerController>().Camera.LockCursor(false);
                ServiceLocator._PlayerController.SetActive(true);
                //need to turn off collision after so you can't restart this interaction
                GameObject keyDesk = GameObject.Find("KEY_Desk"); 
             
                keyDesk.GetComponent<MeshCollider>().enabled = true;
                Destroy(keyDesk.GetComponent<ESCKey>());
                break;
        }   
    }
}
