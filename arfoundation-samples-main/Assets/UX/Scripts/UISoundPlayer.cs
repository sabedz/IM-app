using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISoundPlayer : MonoBehaviour
{
    public AudioSource theSound;
    public GameObject theSource;

    private AudioSource source { get { return GetComponent<AudioSource>(); } }
    private Button button { get { return GetComponent<Button>(); } }
    // Start is called before the first frame update
    void Start()
    {
        theSound = theSource.GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        if (SoundEffectsToggle.isOn == true)
        {
            theSound.Play();
        }
    }
}
