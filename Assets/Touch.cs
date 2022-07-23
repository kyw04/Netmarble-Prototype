using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Touch : MonoBehaviour
{
    public Text touchText;
    public Text inputText;
    private Camera cam;
    private Vector2 touch;
    private float sizeY;
    private bool isRight;
    private int index;

    private void Start()
    {
        cam = Camera.main;
        sizeY = cam.orthographicSize * 2;
        sizeY /= 3;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0).position;


            if (touch.x < 0)
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
