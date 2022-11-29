using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    public Image image;
    public Button button;

    public void Awake()
    {
        //DontDestroyOnLoad(this);
    }

    public void Fadebutton()
    {
        button.gameObject.SetActive(false);
        StartCoroutine(Fadecin());
        
        
    }
    public void Fadeoutbutton()
    {
        StartCoroutine(Fadeout());
    }
    IEnumerator Fadecin()
    {
        float fadecount = 0;
        while(fadecount < 1.0f)
        {
            fadecount += 0.001f;
            yield return new WaitForSeconds(0.001f);
            image.color = new Color(0, 0, 0, fadecount);
        }
        //Invoke("Fadeoutbutton", 0.5f);
        Invoke("startmain", 0.5f);
    }
    IEnumerator Fadeout()
    {
        float fadecount = 1;
        while (fadecount > 0f)
        {
            fadecount -= 0.001f;
            yield return new WaitForSeconds(0.001f);
            image.color = new Color(0, 0, 0, fadecount);
        }
    }
    public void startmain()
    {
        SceneManager.LoadScene("pro");
    }
}
