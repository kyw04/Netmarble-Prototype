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
    public TextMeshProUGUI text;
    int clickCount = 0;
    public string SceneToLoad;

    void start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (clickCount == 0)
            {
                text.text = "hi.";
                clickCount++;
            } else if (clickCount == 1)
            {
                SceneManager.LoadScene(SceneToLoad);
            }

            Debug.Log(clickCount);
        }

    }
}
