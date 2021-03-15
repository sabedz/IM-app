using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class SpearRotation : MonoBehaviour
{
    private Camera arCamera;
    private GameObject arSession;

    // Start is called before the first frame update
    void Start()
    {
        arSession = GameObject.Find("AR Session Origin");
        arCamera = arSession.GetComponent<Camera>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = arCamera.transform.rotation;        
    }
}
