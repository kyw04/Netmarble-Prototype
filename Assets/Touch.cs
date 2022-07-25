using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Touch : MonoBehaviour
{
    public Text touchText;
    public Text inputText;
    public Text XYText;
    private Vector2 touch;
    private float sizeY;
    private float sizeX;
    private bool isRight;
    private int index;

    private void Start()
    {
        sizeY = Screen.height / 3;
        sizeX = Screen.width / 2;
        XYText.text = "X : " + sizeX.ToString() + ' ' + Screen.width.ToString() + "\nY : " + sizeY.ToString() + ' ' + Screen.height.ToString();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0).position;


            if (touch.x > sizeX)
                isRight = true;
            else
                isRight = false;

            if (touch.y <= sizeY)
                index = 0;
            else if (touch.y <= sizeY + sizeY)
                index = 1;
            else
                index = 2;

        }

        touchText.text = touch.ToString();
        inputText.text = index.ToString() + ' ' + isRight.ToString();
    }
}
