using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judgment : MonoBehaviour
{
    public static Judgment Instance;
    public enum Type
    { 
        Bad,
        Good,
        Perfect,
        None
    }
    public Sprite[] sprites;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        Judgment.Instance = this;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void JudgmentChange(Type type)
    {
        spriteRenderer.sprite = sprites[(int)type];
    }
}
