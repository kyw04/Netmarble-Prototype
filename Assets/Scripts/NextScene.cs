using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public string SceneToLoad;

    // Update is called once per frame
    void Update()
    {
        if (!CurtainAni.instance.m_Animator.GetBool("isOpen"))
        {
            CurtainAni.instance.Open();
            SceneManager.LoadScene(SceneToLoad);
        }
    }

    public void StartButtonClick()
    {
        CurtainAni.instance.Close();
    }
}
