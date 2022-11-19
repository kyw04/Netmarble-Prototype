using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            GameObject.Find("Canvass").transform.Find("Book_2").transform.Find("Image").transform.Find("s.c").gameObject.SetActive(true);
            GameObject.Find("Canvass").transform.Find("Book_2").transform.Find("Image").transform.Find("N.C").gameObject.SetActive(false);
        }
        else
        {
            GameObject.Find("Canvass").transform.Find("Book_2").transform.Find("Image").transform.Find("s.c").gameObject.SetActive(false);
            GameObject.Find("Canvass").transform.Find("Book_2").transform.Find("Image").transform.Find("N.C").gameObject.SetActive(true);
        }
    }


    public void asss()
    {
        LV = 0;
    }
}
