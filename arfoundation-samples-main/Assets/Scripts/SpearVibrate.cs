using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.XR.ARFoundation;

public class SpearVibrate : MonoBehaviour
{
    AudioSource targetHit;
    public ParticleSystem destroySpear;

    private GameController gameController;

    private int scoreValue;

    private Camera arCamera;
    private GameObject arSession;

    // Start is called before the first frame update
    void Start()
    {
        scoreValue = 5;

        arSession = GameObject.Find("AR Session Origin");
        arCamera = arSession.GetComponent<Camera>();

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
        transform.rotation = arCamera.transform.rotation;
    }
}
