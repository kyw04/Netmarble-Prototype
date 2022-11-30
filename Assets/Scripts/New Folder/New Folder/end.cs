using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class end : MonoBehaviour
{
    public void Start()
    {
        PlayerPrefs.SetInt("End", 1);
    }
}
