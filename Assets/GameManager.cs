using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject menuSet;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
            GameQuit();

        if (Input.GetKeyDown(KeyCode.Home) || Input.GetKeyDown(KeyCode.Menu))
        {
            ISelectHandler();
        }

    }

    public void GameQuit()
    {
        Application.Quit();
    }

    public void ISelectHandler()
    {
        if (menuSet.activeSelf)
        {
            menuSet.SetActive(false);
        }
        else
        {
            menuSet.SetActive(true);
        }
    }

}
