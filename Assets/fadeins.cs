using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeins : MonoBehaviour
{
    Animator anim;
    public void onclick()
    {
        anim.SetTrigger("fadein");
    }
}
