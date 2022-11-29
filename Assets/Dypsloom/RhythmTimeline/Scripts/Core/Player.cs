using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dypsloom.RhythmTimeline.Core.Managers;
using UnityEngine.UI;
using Dypsloom.RhythmTimeline.Scoring;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    public ScoreManager scoreManager;
    public GameObject[] backgrounds;
    public GameObject[] players;
    public RhythmGameManager gameManager;
    public Image HPSprite;
    public GameObject gameOverPlane;
    private float currentHP;
    private float maxHP = 10;
    private int i;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        i = PlayerPrefs.GetInt("SelectedStage");
        backgrounds[0].SetActive(false);
        players[0].SetActive(false);
        backgrounds[i].SetActive(true);
        players[i].SetActive(true);
        SetHP();
    }

    public void OnDamaged(int damage)
    {
        currentHP -= damage;

        if (currentHP <= 0)
        {
            currentHP = 0;

            scoreManager.Dead();
            gameManager.GameOver();
        }

        HPSprite.fillAmount = currentHP / maxHP;
    }

    public void SetHP()
    {
        currentHP = maxHP;
        HPSprite.fillAmount = 1;
    }

    public void Heal(int value)
    {
        currentHP += value;

        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }

        HPSprite.fillAmount = currentHP / maxHP;
    }

}
