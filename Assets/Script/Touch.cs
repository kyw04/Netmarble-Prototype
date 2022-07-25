using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;

public class Touch : MonoBehaviour
{
    public GameObject[] lights;
    public Text touchText;
    public Text inputText;
    public Text XYText;
    private Vector2[] touch = new Vector2[10];
    private float sizeY;
    private float sizeX;
    private int index;

    private void Start()
    {
        sizeY = Screen.height / 3.0f;
        sizeX = Screen.width / 2.0f;
        XYText.text = "X : " + sizeX.ToString() + ' ' + Screen.width.ToString() + "\nY : " + sizeY.ToString() + ' ' + Screen.height.ToString();
    }

    void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                touch[i] = Input.GetTouch(i).position;


                if (touch[i].x > sizeX)
                    index = 3;
                else
                    index = 0;

                if (touch[i].y <= sizeY)
                    index += 0;
                else if (touch[i].y <= sizeY + sizeY)
                    index += 1;
                else
                    index += 2;

                lights[index].GetComponent<Light2D>().intensity = 2.5f;
            }
        }

        for (int i = 0; i < lights.Length; i++)
        {
            if (lights[i].GetComponent<Light2D>().intensity > 0)
                lights[i].GetComponent<Light2D>().intensity -= Time.deltaTime;
            if (lights[i].GetComponent<Light2D>().intensity < 0)
                lights[i].GetComponent<Light2D>().intensity = 0;
        }

        touchText.text = touch[0].ToString();
        inputText.text = index.ToString();
    }
}
