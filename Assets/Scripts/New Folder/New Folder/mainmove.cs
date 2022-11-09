using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainmove : MonoBehaviour
{
    public GameObject[] Book;
    public int index = 0;

    private void Start()
    {
        index = 0;
    }

    private void Update()
    {
        if (!CurtainAni.instance.m_Animator.GetBool("isOpen"))
        {
            CurtainAni.instance.Open();
            BookSetActive();
        }
    }

    public void  onclickbutton() // right
    {
        CurtainAni.instance.Close();
        index = (index + 1) % Book.Length;
        Debug.Log(index);
    }
    public void  onclickbuttons() // left
    {
        CurtainAni.instance.Close();
        index = index - 1 < 0 ? Book.Length - 1 : index - 1;
        Debug.Log(index);
    }

    public void BookSetActive()
    {
        Book[index].SetActive(true);

        if (index != 0)
            Book[index - 1].SetActive(false);
        else
            Book[Book.Length - 1].SetActive(false);
    }
}
