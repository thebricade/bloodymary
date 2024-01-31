using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using TMPro;
using UnityEngine.UI;

public class SearchEngine : MonoBehaviour
{
    public GameObject searchField;
  


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        bool searchBloodyMary = DialogueLua.GetVariable("Keyword_Witchcraft").asBool;
        Debug.Log(searchBloodyMary);
        if (searchBloodyMary)
        {
            searchField.GetComponent<TMP_InputField>().selectionColor = Color.red;
            searchField.GetComponent<TMP_InputField>().text = "witchcraft"; 
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
