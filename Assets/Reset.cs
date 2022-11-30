using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dypsloom.RhythmTimeline.Scoring;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    public SaveManager saveManager;
    public void ResetButton()
    {
        PlayerPrefs.DeleteAll();
        saveManager.RemoveData();
        Application.Quit();
    }
}
