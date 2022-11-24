using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fade : MonoBehaviour
{
    public Image image;
    public void buttonFadeIn()
    {
        StartCoroutine("FadeIn");
        Invoke("buttomFadeout", 1f);
    }
    public void buttonFadeout()
    {
        StartCoroutine("FadeOut");
    }
    public IEnumerator FadeIn(float time)
    {
        Color color = image.color;
        while (color.a > 0f)
        {
            color.a -= Time.deltaTime / time;
            image.color = color;
            yield return null;
        }
    }

    public IEnumerator FadeOut(float time)
    {
        Color color = image.color;
        while (color.a < 1f)
        {
            color.a += Time.deltaTime / time;
            image.color = color;
            yield return null;
        }
    }
}
