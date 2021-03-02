using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class SpearVibrate : MonoBehaviour
{
    AudioSource targetHit;

    // Start is called before the first frame update
    void Start()
    {
        targetHit = GetComponent<AudioSource>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            Handheld.Vibrate();
            targetHit.Play();
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
