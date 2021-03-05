using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class SpearVibrate : MonoBehaviour
{
    AudioSource targetHit;
    public ParticleSystem destroySpear;

    private GameController gameController;

    private int scoreValue;

    // Start is called before the first frame update
    void Start()
    {
        scoreValue = 5;


        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if(gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if(gameController == null)
        {
            Debug.Log("Cannot find Game Controller");
        }


        targetHit = GetComponent<AudioSource>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            Handheld.Vibrate();
            targetHit.Play();
            gameController.AddScore(scoreValue);
        }

        if (other.CompareTag("Colosseum"))
        {
            Instantiate(destroySpear, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
