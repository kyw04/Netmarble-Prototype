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

        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("삭제 완료");
        }
    }

    public void StartButtonClick()
    {
        CurtainAni.instance.Close();

        if (PlayerPrefs.GetInt("Prologue") > 0)
        {
            SceneToLoad = "Test_main";
        }
        else
        {
            SceneToLoad = "pro";
        }
    }
}
