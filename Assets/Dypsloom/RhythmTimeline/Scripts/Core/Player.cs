using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dypsloom.RhythmTimeline.Core.Managers;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    public RhythmGameManager gameManager;
    public Image HPSprite;
    public GameObject gameOverPlane;
    private float currentHP;
    private float maxHP = 10;

    private void Awake()
    {   
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        SetHP();
    }

    public void OnDamaged(int damage)
    {
        currentHP -= damage;

        if (currentHP <= 0)
        {
            currentHP = 0;

            gameManager.GameOver();
            gameOverPlane.SetActive(true);
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
