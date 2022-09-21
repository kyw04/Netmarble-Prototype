using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;
using TMPro;

public class talkManager : MonoBehaviour
{
    public GameObject talkPanel;
    public TextMeshProUGUI text, textname;
    int clickCount = 0;
    public string SceneToLoad;
    string a = "girl1", b = "girl2";


    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            if (clickCount == 0)
            {
                textname.text = a;
                text.text = "hi.";
                clickCount++;
                textname.text = b;
                text.text = "Good.";
                
            }
            else if (clickCount == 1)
            {
                SceneManager.LoadScene(SceneToLoad);
            }

            Debug.Log(clickCount);
        }

    }
}