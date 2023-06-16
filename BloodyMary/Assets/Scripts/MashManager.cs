using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MashManager : MonoBehaviour
{
    public int answersNeeded;
    private SceneManger _SceneManger;
    public GameObject[] subject;
    public bool[] triggeredSubject; 
    
    // Start is called before the first frame update
    void Start()
    {
        _SceneManger = ServiceLocator._SceneManger; 
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void TappedSubject(string whichSubject)
    {
        Debug.Log("touched a thing");
        GameObject currentSubject = null;
        var  flowchart = ServiceLocator._Flowchart; 
        switch (whichSubject)
        {
            case "husband":
                currentSubject = subject[0];
                currentSubject.transform.GetChild(0).gameObject.SetActive(true);
                currentSubject.transform.GetChild(1).gameObject.SetActive(true);
                triggeredSubject[0] = true;
                flowchart.SendFungusMessage("mashHusband");
                CheckMashCompete();
                break;
            case "kids":
                currentSubject = subject[1];
                currentSubject.transform.GetChild(0).gameObject.SetActive(true);
                currentSubject.transform.GetChild(1).gameObject.SetActive(true);
                triggeredSubject[1] = true;
                CheckMashCompete();
                break;
            case "car":
                currentSubject = subject[2];
                currentSubject.transform.GetChild(0).gameObject.SetActive(true);
                currentSubject.transform.GetChild(1).gameObject.SetActive(true);
                triggeredSubject[2] = true;
                CheckMashCompete();
                break;
            case "honeymoon":
                currentSubject = subject[3];
                currentSubject.transform.GetChild(0).gameObject.SetActive(true);
                currentSubject.transform.GetChild(1).gameObject.SetActive(true);
                triggeredSubject[3] = true;
                CheckMashCompete();
                break; 
            case "job":
                currentSubject = subject[4];
                currentSubject.transform.GetChild(0).gameObject.SetActive(true);
                currentSubject.transform.GetChild(1).gameObject.SetActive(true);
                triggeredSubject[4] = true;
                CheckMashCompete();
                break; 
            case "dress":
                currentSubject = subject[5];
                currentSubject.transform.GetChild(0).gameObject.SetActive(true);
                currentSubject.transform.GetChild(1).gameObject.SetActive(true);
                triggeredSubject[5] = true;
                CheckMashCompete();
                
                break; 
        }
    }

    private void CheckMashCompete()
    {
        if (triggeredSubject.All(x =>x == true))
        {
            _SceneManger.ChangeScene(SceneManger.GameScenes.AolIntro);
        }
    }



}
