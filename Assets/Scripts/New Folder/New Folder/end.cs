using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class end : MonoBehaviour
{
    public GameObject[] images;
    public Text tx;
    public string m_Text;
    public string[] contents;
    public int index = 0;
    public bool isEnd = false;

    public void Start()
    {
        StartCoroutine(onclickbutton());
        PlayerPrefs.SetInt("End", 1);
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
    IEnumerator onclickbutton()
    {
        for (int i = 0; i < images.Length; i++)
        {
            index++;
            ChangeContents();
            StartCoroutine(typing());
            yield return new WaitForSeconds(4f);
        }

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
        m_Text = contents[index];
    }

    IEnumerator typing()
    {
        for (int i = 0; i <= m_Text.Length; i++)
        {
            tx.text = m_Text.Substring(0, i);
            yield return new WaitForSeconds(0.03f);
        }
    }
}