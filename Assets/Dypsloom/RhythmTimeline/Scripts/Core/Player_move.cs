using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime;
/*using System.Runtime.Remoting.Services;*/
using UnityEngine;
using UnityEngine.UI;

public class Player_move : MonoBehaviour
{
    public static Player_move instence;
    //private SpriteRenderer spriteRenderer;
    public Animator m_Animator;
    public Animator cam_Animator;
    public Animator combo_Animator;
    public Animator score_Animator;
    private float startScale;
    //private Vector2 sceneSize;

    void Start()
    {
        //spriteRenderer = GetComponent<SpriteRenderer>();
        m_Animator = GetComponent<Animator>();
        startScale = transform.localScale.x;

        //sceneSize = new Vector2(Screen.width, Screen.height);
    }

    void Update()
    {
        if (instence == null && gameObject.activeSelf == true)
        {
            instence = this;
        }

        if (Input.GetMouseButton(0))
        {
            //Vector2 touchDeltaPosition = Input.GetTouch(0).position - Input.GetTouch(0).rawPosition;
            Vector2 mousePosition = Input.mousePosition;
            //Debug.Log(mousePosition.ToString() + (Screen.height / 3).ToString());

            int direction = mousePosition.x < Screen.width / 2 ? 1 : -1; // 오른쪽 왼쪽 판별
            transform.localScale = new Vector3(direction * startScale, startScale, startScale); // 방향 변경
            float height = Screen.height / 3;
            m_Animator.SetTrigger("Touch");

            if (mousePosition.y < height)
            {
                m_Animator.SetFloat("Blend", 1f);
            }
            else if (mousePosition.y < height * 2)
            {
                m_Animator.SetFloat("Blend", 0.5f);
            }
            else
            {
                m_Animator.SetFloat("Blend", 0f);
            }
        }
    }


    public void Hit()
    {
        //cam_Animator.SetTrigger("Hit");
        m_Animator.SetTrigger("Hit");
    }

    public void ComboStack()
    {
        combo_Animator.SetTrigger("Stack");
    }

    public void AddScore()
    {
        score_Animator.SetTrigger("Add");
    }
}
