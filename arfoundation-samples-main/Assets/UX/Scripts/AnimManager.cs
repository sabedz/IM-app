using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimManager : MonoBehaviour
{
    Animator m_Animator;

    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
    }


    public void setConsoleTrue()
    {
        m_Animator.SetBool("consoleIn", true);
    }

    public void setConsoleFalse()
    {
        m_Animator.SetBool("consoleIn", false);
    }
}
