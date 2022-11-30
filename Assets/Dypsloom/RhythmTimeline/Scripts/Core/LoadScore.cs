using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dypsloom.RhythmTimeline.UI;
using Dypsloom.RhythmTimeline.Core;
using Dypsloom.RhythmTimeline.Core.Managers;
using Dypsloom.RhythmTimeline.Scoring;
using System;

public class LoadScore : MonoBehaviour
{
    public HighScoreUI m_HighScoreUi;
    private RhythmGameManager gameManager;
    private RhythmTimelineAsset[] stage_list;
    private int index = 0;
    private int highIndex = 0;


    private void Start()
    {
        gameManager = GetComponent<RhythmGameManager>();
        stage_list = gameManager.Songs;
        
        if (PlayerPrefs.HasKey("SelectedStage"))
            index = PlayerPrefs.GetInt("SelectedStage");

        if (PlayerPrefs.HasKey("LV"))
            highIndex = PlayerPrefs.GetInt("LV");
    }

    public void ChangeStage(int value)
    {
        index = value;
    }

    public void SelectStage()
    {
        PlayerPrefs.SetInt("SelectedStage", index);
        Debug.Log(stage_list[index].HighScore.FullScore);

        if (stage_list[index].HighScore == null)
        {
            m_HighScoreUi.gameObject.SetActive(false);
        }
        stage_list[index].HighScore.Initialize(ScoreManager.Instance.ScoreSettings, stage_list[index]);

        if (stage_list[index].HighScore.FullScore > 0)// 점수가 있을 경우
        {
            Debug.Log("점수 출력");
            m_HighScoreUi.transform.parent.gameObject.SetActive(true);
            m_HighScoreUi.SetScoreData(stage_list[index].HighScore);

            if (index + 1 > highIndex)
            {
                highIndex = index + 1;
                PlayerPrefs.SetInt("LV", highIndex);
            }
        }
        else
        {
            m_HighScoreUi.transform.parent.gameObject.SetActive(false);
        }
    }
}
