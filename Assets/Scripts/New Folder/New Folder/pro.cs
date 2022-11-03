using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pro : MonoBehaviour
{

    public GameObject target1;
    public GameObject target2;
    public GameObject target3;
    public GameObject target4;
    public int main = 0;
    void Update()
    {
        if (main == 1)
        {
            target1.SetActive(false);
        }
        if (main == 2)
        {
            target2.SetActive(false);
        }
        if (main == 3)
        {
            target3.SetActive(false);
        }
        if (main == 4)
        {
            target4.SetActive(false);
        }
    }
    public void onclickbutton()
    {
        main++;
    }
}
