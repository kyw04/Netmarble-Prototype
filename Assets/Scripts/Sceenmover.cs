using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sceenmover : MonoBehaviour
{
    
    public void pro()
    {
        SceneManager.LoadScene("pro");
    }
    public void inmain()
    {
        SceneManager.LoadScene("Test_main");
    }
    public void ingame()
    {
        SceneManager.LoadScene("TestScene");
    }
}
