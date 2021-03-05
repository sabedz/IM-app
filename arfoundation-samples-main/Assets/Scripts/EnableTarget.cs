using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableTarget : MonoBehaviour
{
    private GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Target");  

        target.SetActive(true);      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
