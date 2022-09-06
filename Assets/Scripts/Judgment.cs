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
    public float eraseSpeed;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        Judgment.Instance = this;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void JudgmentChange(Type type)
    {
        spriteRenderer.sprite = sprites[(int)type];
        spriteRenderer.color = Color.white;
    }

    private void Update()
    {
        if (spriteRenderer.color.a > 0)
        {
            spriteRenderer.color -= new Color(0, 0, 0, eraseSpeed * Time.deltaTime);
        }
    }
}
