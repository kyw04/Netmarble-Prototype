using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveseen : MonoBehaviour
{
    // Start is called before the first frame update


    // Update is called once per frame
    public void Onclickbutton()
    {
        Game_manager.target();
        SceneManager.LoadScene("main");

    }
    public void Onclickbuttonss()
    {

        SceneManager.LoadScene("main");

    }
}
