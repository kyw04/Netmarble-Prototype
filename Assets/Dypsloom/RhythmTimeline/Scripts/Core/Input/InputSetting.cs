using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSetting : MonoBehaviour
{
    public BoxCollider[] inputBox;
    public TouchFeedback[] touchFeedback;
    private Camera mainCamera;
    private float sizeY;
    private float sizeX;

    void Start()
    {
        mainCamera = Camera.main;

        sizeY = mainCamera.orthographicSize * 2f;
        sizeX = mainCamera.aspect * sizeY;
        sizeY /= 3;
        sizeX /= 2;

        Vector3 boxSize = new Vector3(sizeX, sizeY, 1);
        Vector3 position;

        for (int i = 0; i < inputBox.Length; i++)
        {
            float posX = i / 3 == 0 ? -1 : 1;
            posX *= sizeX / 2f;
            float posY = (i % 3 - 1) * sizeY;
            position = new Vector3(posX, posY, 0);

            inputBox[i].transform.position = position;

            inputBox[i].size = boxSize;
            touchFeedback[i].transform.GetChild(0).localScale = boxSize;
        }
    }

    //public void Update()
    //{
    //    if (Input.GetMouseButton(0))
    //    {
    //        int index;
    //        Vector2 mousePosition = Input.mousePosition;

    //        index = mousePosition.x < Screen.width / 2 ? 0 : 3;
    //        float height = Screen.height / 3;

    //        if (mousePosition.y < height)
    //        {
    //            index += 2;
    //        }
    //        else if (mousePosition.y < height * 2)
    //        {
    //            index += 1;
    //        }
    //        else
    //        {
    //            index += 0;
    //        }

    //        touchFeedback[index].TouchFeedbackStart();
    //    }
    //}
}
