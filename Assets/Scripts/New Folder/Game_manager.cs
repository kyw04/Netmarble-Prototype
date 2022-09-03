using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_manager : MonoBehaviour
{
    public int LV = 0;
    public static System.Action target;
    public static System.Action targets;
    void Awake()
    {
        target = () => 
        {
            lv();
        };
        targets = () =>
        {
            lvss();
        };
          DontDestroyOnLoad(gameObject);
    }

    public void lv()
    {
        LV++;
    }

    public void lvss()
    {
        if(LV == 1)
        {

            GameObject.Find("QWERTY").transform.Find("1111").gameObject.SetActive(true);

        }
        else
        {
            GameObject.Find("QWERTY").transform.Find("1111").gameObject.SetActive(false);
        }

    }
    public void asss()
    {
        LV = 0;
    }


}
