using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class pro : MonoBehaviour
{
    public GameObject[] images;
    public Text tx;
    public string m_Text;
    public string[] contents;
    public int index = 0;
    public bool isEnd = false;

    private IEnumerator enumerator;

    public void Start()
    {
        PlayerPrefs.SetInt("Prologue", 1);
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
        if (enumerator == null)
        {
            enumerator = typing();
            index++;
            ChangeContents();
        }
        else
        {
            StopCoroutine(enumerator);
            enumerator = null;
            tx.text = contents[index];
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
        StartCoroutine(enumerator);
    }

    IEnumerator typing()
    {
        for (int i = 0; i <= m_Text.Length; i++)
        {
            tx.text = m_Text.Substring(0, i);
            yield return new WaitForSeconds(0.1f);
        }
        enumerator = null;
    }
}