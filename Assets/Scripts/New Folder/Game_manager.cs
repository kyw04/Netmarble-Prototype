using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_manager : MonoBehaviour
{
    public static int score = 0;
    public Text scoretext;
    public Text HighscoreText;
    private int savedscore = 0;
    private string keystring = "highscore";
    public int LV = 0;
    public static System.Action target;
    public static System.Action targets;
    void Awake()
    {
        target = () => 
        {
            lv();
        };
        targets = () =>
        {
            lvss();
        };
          DontDestroyOnLoad(gameObject);
        savedscore = PlayerPrefs.GetInt(keystring,0);
        HighscoreText.text = "high score" + savedscore.ToString("0");
    }
    void Update()
    {
        scoretext.text = "score:" + score.ToString("0");
        if(score > savedscore)
        {
            PlayerPrefs.SetInt(keystring,score);
        }
    }
    public void scoreup()
    {
        score++;
    }

    public void lv()
    {
        LV++;
    }

    public void lvss()
    {
        if(LV == 1)
        {

            GameObject.Find("QWERTY").transform.Find("1111").gameObject.SetActive(true);

        }
        else
        {
            GameObject.Find("QWERTY").transform.Find("1111").gameObject.SetActive(false);
        }

    }
    public void asss()
    {
        LV = 0;
    }


}
