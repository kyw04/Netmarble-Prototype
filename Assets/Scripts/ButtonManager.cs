using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void RestartButtonClick()
    {
        CurtainAni.instance.Open();
        SceneManager.LoadScene("Scenes/InGame/TestScene");
    }
}
