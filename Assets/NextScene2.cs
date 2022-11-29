using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class NextScene2 : MonoBehaviour
{
    public string SceneToLoad;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButtonClick()
    {

        if (PlayerPrefs.GetInt("Prologue") > 0)
        {
            SceneToLoad = "Test_main";
        }
        else
        {
            SceneToLoad = "end";
        }
    }
}
