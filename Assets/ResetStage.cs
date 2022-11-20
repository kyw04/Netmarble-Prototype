using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetStage : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetInt("SelectedStage", 0);
    }
}
