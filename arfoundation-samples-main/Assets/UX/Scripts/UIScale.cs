using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScale : MonoBehaviour
{
    float value;
    public Slider slider;
    public GameObject menuBtn, resetBtn, voiceBtn, goBtn, setBtn, helpBtn;

    void Awake()
    {
        value = (PlayerPrefs.GetFloat("scaleValue"));
        slider.value = value;
        menuBtn.transform.localScale = new Vector3(value, value, value);
        resetBtn.transform.localScale = new Vector3(value, value, value);
        voiceBtn.transform.localScale = new Vector3(value, value, value);
        goBtn.transform.localScale = new Vector3(value, value, value);
        setBtn.transform.localScale = new Vector3(value, value, value);
        helpBtn.transform.localScale = new Vector3(value, value, value);
    }

    // Update is called once per frame
    void Update()
    {
        value = slider.value;
    }
    void OnEnable()
    {
        //Subscribe to the Slider Click event
        slider.onValueChanged.AddListener(delegate { ChangeScale(); });

    }

    void ChangeScale()
    {
        PlayerPrefs.SetFloat("scaleValue", value);
        menuBtn.transform.localScale = new Vector3(value, value, value);
        resetBtn.transform.localScale = new Vector3(value, value, value);
        voiceBtn.transform.localScale = new Vector3(value, value, value);
        goBtn.transform.localScale = new Vector3(value, value, value);
        setBtn.transform.localScale = new Vector3(value, value, value);
        helpBtn.transform.localScale = new Vector3(value, value, value);
    }
}
