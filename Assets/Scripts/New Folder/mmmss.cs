using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mmmss : MonoBehaviour
{
    // Start is called before the first frame update
    public void Onclickbutton()
    {
        GameObject.Find("QWERTY").transform.Find("mmm").gameObject.SetActive(true);

    }
    public void Onclickbuttons()
    {
        GameObject.Find("QWERTY").transform.Find("mmm").gameObject.SetActive(false);

    }
}
