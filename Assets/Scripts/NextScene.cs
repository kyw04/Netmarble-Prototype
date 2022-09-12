using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public string SceneToLoad;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Input.touchCount >= 1
        {
            SceneManager.LoadScene(SceneToLoad);
        }
    }
    
}
