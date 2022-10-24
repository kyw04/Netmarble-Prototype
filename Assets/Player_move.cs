using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime;
/*using System.Runtime.Remoting.Services;*/
using UnityEngine;
using UnityEngine.UI;

public class Player_move : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Animator anim;
    private float startScale;
    //private Vector2 sceneSize;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        startScale = transform.localScale.x;

        //sceneSize = new Vector2(Screen.width, Screen.height);
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //Vector2 touchDeltaPosition = Input.GetTouch(0).position - Input.GetTouch(0).rawPosition;
            Vector2 mousePosition = Input.mousePosition;
            //Debug.Log(mousePosition.ToString() + (Screen.height / 3).ToString());

            int direction = mousePosition.x < Screen.width / 2 ? 1 : -1; // 오른쪽 왼쪽 판별
            transform.localScale = new Vector3(direction * startScale, startScale, startScale); // 방향 변경
            float height = Screen.height / 3;

            

            if (mousePosition.y < height)
            {
                anim.SetFloat("Blend", 1f);
            }
            else if (mousePosition.y < height * 2)
            {
                anim.SetFloat("Blend", 0.5f);
            }
            else
            {
                anim.SetFloat("Blend", 0f);
            }
        }
    }
}
