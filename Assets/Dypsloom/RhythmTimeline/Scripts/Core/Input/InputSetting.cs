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
            float dir = i / 3 == 0 ? -1 : 1;
            float posX = dir * sizeX / 2f;
            posX += 1.5f * dir;
            float posY = (i % 3 - 1) * sizeY;
            position = new Vector3(posX, posY, 0);

            inputBox[i].transform.position = position;

            inputBox[i].size = boxSize;
            touchFeedback[i].transform.GetChild(0).localScale = boxSize;
        }
    }

    public void Update()
    {
        if (!CurtainAni.instance.m_Animator.GetBool("isOpen") || CurtainAni.instance.m_Animator.GetBool("Closing"))
        {
            for (int i = 0; i < inputBox.Length; i++)
            {
                inputBox[i].gameObject.SetActive(false);
                touchFeedback[i].gameObject.SetActive(false);
            }

        }
        else
        {
            for (int i = 0; i < inputBox.Length; i++)
            {
                inputBox[i].gameObject.SetActive(true);
                touchFeedback[i].gameObject.SetActive(true);
            }
        }
    }
}
