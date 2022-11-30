using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticCanvasSetting : MonoBehaviour
{
    private Canvas m_Canvas;
    private void Start()
    {
        m_Canvas = GetComponent<Canvas>();
    }

    private void Update()
    {
        if (m_Canvas.worldCamera == null)
        {
            Debug.Log("카메라 세팅");
            m_Canvas.worldCamera = Camera.main;
        }
    }
}
