using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UP : MonoBehaviour
{
    public static int score = 0;
    public static System.Action target;
    public Text scoretext;
    public Text HighscoreText;
    private int savedscore = 0;
    private string keystring = "highscore";
    // Start is called before the first frame update
    public void scoreup()
    {
        score++;
    }

    private void Awake()
    {
        savedscore = PlayerPrefs.GetInt(keystring, 0);
        HighscoreText.text = "high score" + savedscore.ToString("0");
        target = () =>
        {
            scoreup();
        };
        DontDestroyOnLoad(gameObject);
    }
    void Update()
    {
        scoretext.text = "score:" + score.ToString("0");
        if (score > savedscore)
        {
            PlayerPrefs.SetInt(keystring, score);
        }
    }
}
