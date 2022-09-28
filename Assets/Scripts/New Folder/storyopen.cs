using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class storyopen : MonoBehaviour
{
    public void Onclickbuttons()
    {
        GameObject.Find("QWERTY").transform.Find("mmm").GetChild(2).GetChild(0).GetChild(1).GetChild(0).gameObject.SetActive(true);

    }
    public void Onclickbuttonss()
    {
        GameObject.Find("QWERTY").transform.Find("mmm").GetChild(2).GetChild(0).GetChild(1).GetChild(0).gameObject.SetActive(false);

    }
}
