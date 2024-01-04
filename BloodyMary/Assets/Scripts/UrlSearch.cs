using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UrlSearch : MonoBehaviour
{
    public GameObject inputField;
    public GameObject search;
    public GameObject blog;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckURL()
    {
        //this might be better as a switch statement
        var currentURL = inputField.GetComponent<TMP_InputField>().text;
        if (currentURL == "begin") // need to convert to lowercase
        {
            Debug.Log("you made it");
            search.SetActive(true);
            //turn everything else off
            blog.SetActive(false);
        }
        else
        {
            Debug.Log("401 error");
        }
    }
    
   
}
