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
    public string SceneToLoad;
    


    private void Start()
    {
        gameManager = GetComponent<RhythmGameManager>();
        stage_list = gameManager.Songs;
        
        if (PlayerPrefs.HasKey("SelectedStage"))
            index = PlayerPrefs.GetInt("SelectedStage");
    }

    public void ChangeStage(int value)
    {
        index = value;
    }

    public void SelectStage()
    {
        PlayerPrefs.SetInt("SelectedStage", index);
        Debug.Log(index);

        if (stage_list[index].HighScore == null)
        {
            m_HighScoreUi.gameObject.SetActive(false);
        }
        stage_list[index].HighScore.Initialize(ScoreManager.Instance.ScoreSettings, stage_list[index]);

        if (stage_list[index].HighScore.FullScore > 0)// 점수가 있을 경우
        {
            m_HighScoreUi.transform.parent.gameObject.SetActive(true);
            m_HighScoreUi.SetScoreData(stage_list[index].HighScore);
            if (PlayerPrefs.GetInt("End") > 0)
            {
                SceneToLoad = "Test_main";
            }
            else
            {
                SceneToLoad = "end";
            }
        }
        else
        {
            m_HighScoreUi.transform.parent.gameObject.SetActive(false);
        }
    }
}
