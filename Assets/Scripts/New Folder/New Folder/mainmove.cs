using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainmove : MonoBehaviour
{
    public GameObject[] Book;
    public LoadScore loadScore;
    public int index = 0;
    private bool bookChanage = false;

    private void Start()
    {
        index = 0;

        if (PlayerPrefs.HasKey("SelectedStage"))
            index = PlayerPrefs.GetInt("SelectedStage");

        BookSetActive();
    }

    private void Update()
    {
        if (!CurtainAni.instance.m_Animator.GetBool("isOpen") && !CurtainAni.instance.m_Animator.GetBool("Opening") && !bookChanage)
        {
            CurtainAni.instance.Open();
            BookSetActive();
        }

        if (CurtainAni.instance.m_Animator.GetBool("isOpen"))
        {
            bookChanage = false;
        }
    }

    public void  onclickbutton() // right
    {
        CurtainAni.instance.Close();
        index = (index + 1) % Book.Length;
        loadScore.ChangeStage(index);
    }

    public void  onclickbuttons() // left
    {
        CurtainAni.instance.Close();
        index = index - 1 < 0 ? Book.Length - 1 : index - 1;
        loadScore.ChangeStage(index);
    }

    public void BookSetActive()
    {
        bookChanage = true;
        for (int i = 0; i < Book.Length; i++)
        {
            Book[i].SetActive(false);
        }

        Debug.Log("Change");
        Book[index].SetActive(true);
        loadScore.SelectStage();
    }
}
