using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class fade : MonoBehaviour
{
    public static fade instance;
    public Image image;
    public Button button;
    public Animator anim;

    private bool start = false;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    void Start()
    {
        anim = image.GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("삭제 완료");
        }

        if (Input.GetMouseButton(0) && transform.GetChild(0).gameObject.activeSelf && !start)
        {
            Fadebutton();
        }
    }

    public void Fadebutton()
    {
        //button.gameObject.SetActive(false);
        //StartCoroutine(Fadecin());
        Invoke("startmain", 1f);
        anim.SetTrigger("fadein");
        start = true;
    }
    public void Fadeoutbutton()
    {
        //StartCoroutine(Fadeout());
        anim.SetTrigger("fadeout");
    }
    //IEnumerator Fadecin()
    //{
    //    float fadecount = 0;
    //    while(fadecount < 1.0f)
    //    {
    //        fadecount += 0.01f;
    //        yield return new WaitForSeconds(0.01f);
    //        image.color = new Color(0, 0, 0, fadecount);
    //    }
    //    //Invoke("Fadeoutbutton", 0.5f);
    //    Invoke("startmain", 1f);
    //}
    //IEnumerator Fadeout()
    //{
    //    float fadecount = 1;
    //    while (fadecount > 0f)
    //    {
    //        fadecount -= 0.001f;
    //        yield return new WaitForSeconds(0.001f);
    //        image.color = new Color(0, 0, 0, fadecount);
    //    }
    //}
    public void startmain()
    {
        if (PlayerPrefs.GetInt("Prologue") > 0)
        {
            SceneManager.LoadScene("Test_main");
        }
        else
        {
            SceneManager.LoadScene("pro");
        }
    }
}
