using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colosseum : MonoBehaviour
{
    AudioSource spearDestroy;

    // Start is called before the first frame update
    void Start()
    {
        spearDestroy = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Spear"))
        {
            spearDestroy.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
