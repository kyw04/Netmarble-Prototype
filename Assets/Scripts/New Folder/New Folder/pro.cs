using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class pro : MonoBehaviour
{
    public GameObject[] images;
    public Text tx;
    public Text m_Text;
    public string[] contents;
    public int index = 0;
    public bool isEnd = false;

    public void Start()
    {
        onclickbutton();
        StartCoroutine(typing());
    }
    void Update()
    {
        if (isEnd && !CurtainAni.instance.m_Animator.GetBool("isOpen"))
        {
            CurtainAni.instance.Open();
            Debug.Log("Load Scene");
            SceneManager.LoadScene("Test_main");
        }
    }
    public void onclickbutton()
    {
        index++;
        ChangeContents();
    }

    private void ChangeContents()
    {
        if (index >= images.Length)
        {
            if (!isEnd)
            {
                CurtainAni.instance.Close();
                isEnd = true;
                Debug.Log("End");
            }
            return;
        }

        images[index - 1].SetActive(false);
        images[index].SetActive(true);
        m_Text.text = contents[index];
    }

    IEnumerator typing()
    {
        for (int i = 0; i <= m_Text.Length; i++)
        {
            tx.text = m_Text.Substring(0, i);
            yield return new WaitForSeconds(0.15f);
        }
    }
}