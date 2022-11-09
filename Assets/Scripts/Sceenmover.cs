using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sceenmover : MonoBehaviour
{
    private bool StartGame = false;
    private void Update()
    {
        if (StartGame && !CurtainAni.instance.m_Animator.GetBool("isOpen"))
        {
            CurtainAni.instance.Open();
            SceneManager.LoadScene("TestScene");
        }
    }

    public void pro()
    {
        SceneManager.LoadScene("pro");
    }
    public void inmain()
    {
        SceneManager.LoadScene("Test_main");
    }
    public void ingame()
    {
        CurtainAni.instance.Close();
        StartGame = true;
    }
}
