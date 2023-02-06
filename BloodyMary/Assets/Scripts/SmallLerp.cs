using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallLerp : MonoBehaviour
{
    public float lerpStart;
    public float lerpEnd;
    public Component setComponent; 
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (setComponent.GetComponent<Light>() == true)
        {
            Debug.Log("lightobject");

            setComponent.GetComponent<Light>().intensity = Mathf.PingPong(lerpStart, lerpEnd);
            //when it get so far send it back the other way? rewatch a video on lerping

            //  StartCoroutine(TargetIntensity(lerpStart, lerpEnd));
        }
    }

    IEnumerator TargetIntensity(float startValue, float endValue)
    {
       
        
        yield return null;
    }
}
