using System.Collections;
using System.Collections.Generic;
using TextSpeech;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.Android;
using UnityEngine.SceneManagement;

public class VoiceController : MonoBehaviour
{
    const string LANG_CODE = "en-US";
    float period = 0.0f;

    public Button enableSpear;
    public Button disableSpear;
    public Slider scaleSlider;
    public Slider rotateSlider;

    void Start()
    {
        Setup(LANG_CODE);
    

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
        
        if (result == "throw spear")
        {
            enableSpear.onClick.Invoke();
        }

        if (result == "don't throw spear")
        {
            disableSpear.onClick.Invoke();
        }

        if (result == "increase scale")
        {
            IncreaseScale();
        }

        if (result == "decrease scale")
        {
            DecreaseScale();
        }

        if (result == "increase rotation")
        {
            IncreaseRotate();
        }

        if (result == "decrease rotation")
        {
            DecreaseRotate();
        }

    }

    void IncreaseScale()
    {
        if (scaleSlider.value <= 0.06f)
        {
        scaleSlider.value += .02f;
        }
    }

    void DecreaseScale()
    {
        if (scaleSlider.value >= 0.04f)
        {
        scaleSlider.value -= .02f;
        }
    }

    void IncreaseRotate()
    {
        if(rotateSlider.value <= 270)
        {
            rotateSlider.value += 90f;
        }
    }

    void DecreaseRotate()
    {
        if (rotateSlider.value >= 90f)
        {
        rotateSlider.value -= 90f;
        }
    }

    void OnPartialSpeechResult(string result)
    {
        StartListening();

        if (result == "throw spear")
        {
            enableSpear.onClick.Invoke();
        }

        if (result == "don't throw spear")
        {
            disableSpear.onClick.Invoke();
        }

        if (result == "increase scale")
        {
            IncreaseScale();
        }

        if (result == "decrease scale")
        {
            DecreaseScale();
        }

        if (result == "increase rotation")
        {
            IncreaseRotate();
        }

        if (result == "decrease rotation")
        {
            DecreaseRotate();
        }


    }
    #endregion 


    void Setup(string code)
    {
        TextToSpeech.instance.Setting(code, 1, 1);
        SpeechToText.instance.Setting(code);
    }

} 
