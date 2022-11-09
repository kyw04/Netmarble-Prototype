using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pro : MonoBehaviour
{

    public GameObject target1;
    public GameObject target2;
    public GameObject target3;
    public GameObject target4;
    public int main = 0;

    public bool isEnd = false;
    public void Start()
    {
        main = 1;
    }
    void Update()
    {
        if (main == 1)
        {
            target1.SetActive(true);
            target2.SetActive(false);
            target3.SetActive(false);
            target4.SetActive(false);
        }
        else if (main == 2)
        {
            target1.SetActive(false);
            target2.SetActive(true);
            target3.SetActive(false);
            target4.SetActive(false);

        }
        else if (main == 3)
        {
            target1.SetActive(false);
            target2.SetActive(false);
            target3.SetActive(true);
            target4.SetActive(false);
        }
        else if (main == 4)
        {
            target1.SetActive(false);
            target2.SetActive(false);
            target3.SetActive(false);
            target4.SetActive(true);
        }
        else if (main == 5)
        {
            if (!isEnd)
            {
                CurtainAni.instance.Close();
                isEnd = true;
                Debug.Log("End");
            }
        }

        if (isEnd && !CurtainAni.instance.m_Animator.GetBool("isOpen"))
        {
            CurtainAni.instance.Open();
            Debug.Log("Load Scene");
            SceneManager.LoadScene("Test_main");
        }
    }
    public void onclickbutton()
    {
        main++;
        Debug.Log(main);
    }
}
