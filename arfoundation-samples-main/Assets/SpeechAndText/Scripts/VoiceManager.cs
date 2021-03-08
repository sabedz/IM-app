using System.Collections;
using System.Collections.Generic;
using TextSpeech;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.Android;
using UnityEngine.SceneManagement;

public class VoiceManager : MonoBehaviour
{
    const string LANG_CODE = "en-US";
    float period = 0.0f;
    Animator voiceAnimator;
    Animator helpAnimator;
    public GameObject voiceConsole;
    public GameObject helpAnim;

   // VideoPlayer source;
   // public GameObject ARSession;

    void Start()
    {
        Setup(LANG_CODE);
        voiceAnimator = voiceConsole.GetComponent<Animator> ();
        helpAnimator = helpAnim.GetComponent<Animator>();
        //source = ARSession.GetComponent<VideoPlayer>();

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

        else if (result == "reset")
        {
            loadUX();
        }

        else if (result == "let's go" || result == "go")
        {
            loadMain();
        }

        else if (result == "help")
        {
            AnimHelpIn();
        }

        else if (result == "okay" || result == "okey")
        {
            AnimHelpOut();
        }

        else if (result == "setting" || result == "settings")
        {
            AnimSetIn();
        }
        else if (result == "save")
        {
            AnimSetOut();
        }
    }
    void OnPartialSpeechResult(string result)
    {
        AnimVoice();
        StartListening();

        if (result == "menu")
        {
            loadMenu();
        }
        else if (result == "reset")
        {
            loadUX();
        }

        else if (result == "help")
        {
            AnimHelpIn();
        }

        else if (result == "okay" || result == "okey")
        {
            AnimHelpOut();
        }

        else if (result == "let's go" || result == "go")
        {
            loadMain();
        }
        else if (result == "setting" || result == "settings")
        {
            AnimSetIn();
        }
        else if (result == "save")
        {
            AnimSetOut();
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

    public void AnimVoice()
    {
        voiceAnimator.SetTrigger("help");
        StartListening();
    }

    void AnimHelpIn()
    {
        helpAnimator.SetBool("helpIn", true);
        StartListening();
    }
    void AnimHelpOut()
    {
        helpAnimator.SetBool("helpIn", false);
        StartListening();
    }

    void AnimSetIn()
    {
        helpAnimator.SetBool("setIn", true);
        StartListening();
    }
    void AnimSetOut()
    {
        helpAnimator.SetBool("setIn", false);
        StartListening();
    }

    /*void playMusic()
    {
        source.Play();
    }

    void pauseMusic()
    {
        source.Pause();
    }*/
}
