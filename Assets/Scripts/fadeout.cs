using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fadeout : MonoBehaviour
{
    public Image image;
    public float fadecount = 1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fadeout());
    }
    private void Update()
    {
        if (fadecount <= 0f)
        {
            Destroy(gameObject);
        }

    }
    IEnumerator Fadeout()
    {
        
        while (fadecount > 0f)
        {
            fadecount -= 0.001f;
            yield return new WaitForSeconds(0.001f);
            image.color = new Color(0, 0, 0, fadecount);
            
        }
      
    }
    // Update is called once per frame

}
