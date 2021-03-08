using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VibrationToggle : MonoBehaviour
{
    public static VibrationToggle instance;
    public Toggle vibration;
    public static bool vibIsOn = true;

    void Awake()
    {
        instance = this;
        vibIsOn = (PlayerPrefs.GetInt("vibIsOn") != 0);
    }

    void Start()
    {
        vibration = GetComponent<Toggle>();
        vibration.onValueChanged.AddListener(delegate
        {
            ToggleValueChanged(vibration);
        });

        if (vibIsOn)
        {
            vibration.isOn = true;
        }
        else vibration.isOn = false;
    }

    void ToggleValueChanged(Toggle change)
    {
        if (vibration.isOn)
        {
            vibIsOn = true;
        }
        else
        {
            vibIsOn = false;
        }
        PlayerPrefs.SetInt("vibIsOn", vibIsOn ? 1 : 0);
    }
}
