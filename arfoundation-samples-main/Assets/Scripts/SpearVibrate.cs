using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class SpearVibrate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            Handheld.Vibrate();
        }

        if (other.CompareTag("Colosseum"))
        {
            Destroy(gameObject);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
