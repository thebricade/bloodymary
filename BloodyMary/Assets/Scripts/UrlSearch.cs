using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UrlSearch : MonoBehaviour
{
    public GameObject inputField;
    private string urlText; 
    public GameObject search;
    public GameObject blog;
    public TMP_Dropdown _dropdown;


    private GameObject lastSite; 
    // Start is called before the first frame update
    void Start()
    {
        lastSite = blog;
        urlText = inputField.GetComponent<TMP_InputField>().text; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckURL()
    {
        //this might be better as a switch statement
        var currentURL = inputField.GetComponent<TMP_InputField>().text; 
        //run change website here
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
    

    public void BookMarkSelect()
    {
       
        
        //find out what the person selected
        int pickedEntryIndex = _dropdown.value;
        string selectedOption = _dropdown.options[pickedEntryIndex].text;

        changeWebsite(selectedOption);
        
        Debug.Log(selectedOption);
        
    }


    private void changeWebsite(string website)
    {
     
        Debug.Log("you made it here");
        Debug.Log("last visitied" + lastSite.ToString()); 
        switch (website)
        {
            case "blog":
                lastSite.SetActive(false);
                blog.SetActive(true);
                inputField.GetComponent<TMP_InputField>().text  = "www.blogging.com/amanda";
                lastSite = blog;  
                break;
            case "search":
                lastSite.SetActive(false);
                search.SetActive(true);
                inputField.GetComponent<TMP_InputField>().text  = "www.begin.com";
                lastSite = search; 
                break;
            case "witch":
                lastSite.SetActive(false);
                //blog.SetActive(true);
                inputField.GetComponent<TMP_InputField>().text  = "www.witchesarereal.com";
                break;
        }
    }


    public void AddBookmark(string BookmarkText)
    {
        _dropdown.options.Add(new TMP_Dropdown.OptionData("Testing Bookmark", null));
        _dropdown.RefreshShownValue();
    }



}
