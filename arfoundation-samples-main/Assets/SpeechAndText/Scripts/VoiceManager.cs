using System.Collections;
using System.Collections.Generic;
using TextSpeech;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;
using UnityEngine.SceneManagement;

public class VoiceManager : MonoBehaviour
{
    const string LANG_CODE = "en-US";
    float period = 0.0f;
    Animator helpAnimator;
    public GameObject btnHelp;


    void Start()
    {
        Setup(LANG_CODE);
        helpAnimator = btnHelp.GetComponent<Animator> ();

#if UNITY_ANDROID
        SpeechToText.instance.onPartialResultsCallback = OnPartialSpeechResult;
#endif
        SpeechToText.instance.onResultCallback = OnFinalSpeechResult;
        TextToSpeech.instance.onStartCallBack = OnSpeakStart;
        TextToSpeech.instance.onDoneCallback = OnSpeakStop;

        CheckPermission();
        StartListening();
    }

    void Update()
    {
        if (period > 0.1)
        {
            StartListening();
            period = 0;
        }
        period += UnityEngine.Time.deltaTime;
    }

    void CheckPermission()
    {
#if UNITY_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone)){
        Permission.RequestUserPermission(Permission.Microphone);
    }
#endif
    }

    #region Text to Speech
    public void StartSpeaking(string message)
    {
        TextToSpeech.instance.StartSpeak(message);
    }

    public void StopSpeaking(string message)
    {
        TextToSpeech.instance.StopSpeak();
    }

    void OnSpeakStart()
    {
        Debug.Log("Talking started..");
    }
    void OnSpeakStop()
    {
        Debug.Log("Talking stopped..");
    }
    #endregion

    #region Speech to Text
    public void StartListening()
    {
        SpeechToText.instance.StartRecording();
    }
    public void StopListening()
    {
        SpeechToText.instance.StopRecording();
    }
    void OnFinalSpeechResult(string result)
    {
        if (result == "menu")
        {
            loadMenu();
        }

        else if (result == "let's go" || result == "go")
        {
            loadMain();
        }

        else if (result == "reset")
        {
            loadUX();
        }

        else
        {
            AnimHelp();
            StartListening();
        }

    }
    void OnPartialSpeechResult(string result)
    {
        if (result == "menu")
        {
            loadMenu();
        }
        else if (result == "reset")
        {
            loadUX();
        }

        else if (result == "let's go" || result == "go")
        {
            loadMain();
        }

        else
        {
            AnimHelp();
            StartListening();
        }
    }
    #endregion


    void Setup(string code)
    {
        TextToSpeech.instance.Setting(code, 1, 1);
        SpeechToText.instance.Setting(code);
    }

    public void loadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void loadUX()
    {
        SceneManager.LoadScene("UXManagerScene");
    }

    public void loadMain()
    {
        SceneManager.LoadScene("SimpleAR");
    }

    public void AnimHelp()
    {
        helpAnimator.SetTrigger("help");
        StartListening();
    }
}
