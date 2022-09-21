using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rere : MonoBehaviour
{
    public void Onclickbuttons()
    {
        GameObject.Find("QWERTY").transform.Find("mmm").GetChild(2).GetChild(0).gameObject.SetActive(true);

    }
    public void Onclickbutton()
    {
        GameObject.Find("QWERTY").transform.Find("mmm").GetChild(2).GetChild(0).gameObject.SetActive(false);

    }
}
