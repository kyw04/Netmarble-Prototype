using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;
using TMPro;
using static System.Net.Mime.MediaTypeNames;
/*using System;
using static System.Net.Mime.MediaTypeNames;*/

public class talkManager : MonoBehaviour
{
    public GameObject talkPanel;
    public GameObject nameTag;
    public TextMeshProUGUI text, textname;
    int clickCount = 0;
    public string SceneToLoad;
    string a = "girl1", b = "girl2";
    public GameObject girl1;
    public GameObject girl2;



    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (clickCount == 0)
            {
                textname.text = a;
                text.text = "hi.";
                clickCount++;

            } 
            else if (clickCount == 1){
                textname.text = b;
                text.text = "Good.";
                clickCount++;
            }
            else if (clickCount == 2)
            {
                SceneManager.LoadScene(SceneToLoad);
            }

            Debug.Log(clickCount);
        }

    }
}