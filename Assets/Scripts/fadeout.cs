using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fadeout : MonoBehaviour
{
    void Start()
    {
        fade.instance.Fadeoutbutton();
    }

    private void Update()
    {
        if (fade.instance.anim.GetCurrentAnimatorStateInfo(0).IsName("fade_end"))
        {
            fade.instance.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
