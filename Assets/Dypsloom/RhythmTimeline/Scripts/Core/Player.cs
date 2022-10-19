using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dypsloom.RhythmTimeline.Core.Managers;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    public RhythmGameManager gameManager;
    public GameObject[] HPSprites;
    public GameObject gameOverPlane;
    private int currentHP;
    private int index;
    private int maxHP = 3;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        maxHP = HPSprites.Length;
        SetHP();
    }

    public void OnDamaged(int damage)
    {
        currentHP -= damage;

        for (int i = 0; i < damage && index >= 0; i++)
        {
            HPSprites[index--].SetActive(false);
        }

        if (currentHP <= 0)
        {
            currentHP = 0;

            gameManager.GameOver();
            gameOverPlane.SetActive(true);
        }
    }

    public void SetHP()
    {
        currentHP = maxHP;
        index = maxHP - 1;
        for (int i = 0; i < maxHP; i++)
        {
            HPSprites[i].SetActive(true);
        }
    }
}
