using System.Collections;
using System.Collections.Generic;
using PixelCrushers;
using PixelCrushers.DialogueSystem;
using UnityEngine;

public class TestingMultiChat : MonoBehaviour
{
    public bool onComputer;
    public DialogueSystemController _DialogueManager;
    public DialogueSystemTrigger _DialogueSystemTriggerDaniel, _DialogueSystemTriggerErica;

   // public GameObject ComputerUI1; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (onComputer && Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("escape computer");
           // ComputerUI1.SetActive(false);
           //PixelCrushers.DialogueSystem.DialogueManager.StartConversation("");
            onComputer = false; 
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            _DialogueManager.conversationController.Close();
            Debug.Log(_DialogueManager);
        }
        
    }

// Save the current conversation state
    void SaveConversationState()
    {
        //string conversationState = DialogueManager.instance.GetConversationSaveData();
       // PlayerPrefs.SetString("SavedConversationState", conversationState);
        //PlayerPrefs.Save();
       

    }

    public void DanielConversation()
    {
        if (_DialogueManager.IsConversationActive)
        {
            //_DialogueManager.conversationController.Close();
            _DialogueSystemTriggerErica.enabled = false; 
        }  
        
        _DialogueSystemTriggerDaniel.OnConversationStart(gameObject.GetComponent<Transform>());
    }

    public void EricaConversation()
    {
        if (_DialogueManager.IsConversationActive)
        {
           // _DialogueManager.conversationController.Close();
           _DialogueSystemTriggerDaniel.enabled = false;
        }

       // _DialogueSystemTriggerErica.enabled = true;
        _DialogueSystemTriggerErica.OnConversationStart(gameObject.GetComponent<Transform>());
    }

    public void StartConversation()
    {
       // gameObject.GetComponent<Usable>().OnUseUsable();
        gameObject.GetComponent<DialogueSystemTrigger>().OnConversationStart(gameObject.GetComponent<Transform>());
        Debug.Log("called on use?");
    }

    public void EndConversation()
    {
        gameObject.GetComponent<DialogueSystemTrigger>().OnConversationEnd(gameObject.GetComponent<Transform>());
    }

    public void TestingUnSelect()
    {
        Debug.Log("not selecting");
    }
    
    
}
