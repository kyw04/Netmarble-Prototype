using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurtainAni : MonoBehaviour
{
    public static CurtainAni instance;

    public Animator m_Animator;

    private bool isOpen;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void Open(float t = 0)
    {
        if (!m_Animator.GetBool("isOpen"))
        {
            isOpen = true;
            StartCoroutine("_Open", t);
        }
    }

    private IEnumerator _Open(float t)
    {
        yield return new WaitForSeconds(t);
        m_Animator.SetTrigger("Open");
        StartCoroutine("SetBool");
    }

    public void Close(float t = 0)
    {
        if (m_Animator.GetBool("isOpen"))
        {
            isOpen = false;
            StartCoroutine("_Close", t);
        }
    }

    private IEnumerator _Close(float t)
    {
        yield return new WaitForSeconds(t);
        m_Animator.SetTrigger("Close");
        StartCoroutine("SetBool");
    }

    private IEnumerator SetBool()
    {
        yield return new WaitForSeconds(1f);
        m_Animator.SetBool("isOpen", isOpen);
    }
}
