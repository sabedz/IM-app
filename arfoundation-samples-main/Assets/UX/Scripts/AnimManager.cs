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


    public void setHelpTrue()
    {
        m_Animator.SetBool("helpIn", true);
    }

    public void setHelpFalse()
    {
        m_Animator.SetBool("helpIn", false);
    }
    public void setSetTrue()
    {
        m_Animator.SetBool("setIn", true);
    }

    public void setSetFalse()
    {
        m_Animator.SetBool("setIn", false);
    }
}
