
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


public class CurtainAni : MonoBehaviour
{
    public static CurtainAni instance;
    public Animator m_Animator;
    private PlayableGraph playableGraph;

    private bool isOpen = true;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            playableGraph = PlayableGraph.Create();
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Update()
    {
        if (playableGraph.GetPlayableCount() > 0)
        {
            Debug.Log(playableGraph.GetRootPlayable(0));
        }

        if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("curtain_opened"))
        {
            m_Animator.SetBool("isOpen", true);
            m_Animator.SetBool("Opening", false);
        }
        if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("curtain_closed"))
        {
            m_Animator.SetBool("isOpen", false);
            m_Animator.SetBool("Closing", false);
        }
    }

    public void Open(float t = 0)
    {
        if (!m_Animator.GetBool("isOpen") && !isOpen)
        {
            isOpen = true;
            StartCoroutine("_Open", t);
        }
    }

    private IEnumerator _Open(float t)
    {
        yield return new WaitForSeconds(t);
        m_Animator.SetBool("Opening", true);
    }

    public void Close(float t = 0)
    {
        if (m_Animator.GetBool("isOpen") && isOpen)
        {
            isOpen = false;
            StartCoroutine("_Close", t);
        }
    }

    private IEnumerator _Close(float t)
    {
        yield return new WaitForSeconds(t);
        m_Animator.SetBool("Closing", true);
    }
}
