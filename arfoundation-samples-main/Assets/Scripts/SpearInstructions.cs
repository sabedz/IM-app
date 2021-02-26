using System;
using System.Text;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections;

public class SpearInstructions : MonoBehaviour
{
    public Text textElement;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Instructions());
    }

    IEnumerator Instructions()
    {
        if (textElement.enabled==true)
        {
            yield return new WaitForSeconds(3);
            textElement.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
