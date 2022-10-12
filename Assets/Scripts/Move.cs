using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Move : MonoBehaviour
{
    //public Slider speedSlider;
    public float speed;
    public float value;
    public bool isMove;
    float maxX, maxY;

    void Start()
    {
        value = 10f;
        speed = value * 1000;
        isMove = false;
    }

    // 제자리 위치 지정
    void Mm()
    {
        transform.position = Vector3.Lerp(gameObject.transform.position, new Vector2(0, 0), speed * 0.01f);
    }

    void Update()
    {
        //if (GameObject.FindGameObjectWithTag("BigNote"))
        //    isMove = true;
        //else
        //    isMove = false;

        if (Input.touchCount >= 1 && isMove)
        {

            //Touch touch = Input.GetTouch(0);
            //Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition; // 수정할 부분 주석 처리함  
            Vector2 touchDeltaPosition = Input.GetTouch(0).position - Input.GetTouch(0).rawPosition; // 수정할 코드 추가 

            // 가로, 세로 거리의 절대값
            if (touchDeltaPosition.x < 0)
                maxX = -touchDeltaPosition.x;
            else
                maxX = touchDeltaPosition.x;

            if (touchDeltaPosition.y < 0)
                maxY = -touchDeltaPosition.y;
            else
                maxY = touchDeltaPosition.y;

            // 드래그가 끝났다면
            if ((maxX >= value || maxY >= value) && Input.GetTouch(0).phase == TouchPhase.Ended)
            {

                // 가로 드래그 라면
                if (maxX > maxY)
                {
                    // 왼쪽 드래그 라면
                    if (touchDeltaPosition.x < 0)
                    {
                        transform.position = Vector3.Lerp(gameObject.transform.position, new Vector2(-10, 0), speed * 0.01f);
                        Invoke("Mm", 1f);
                    }
                    // 오른쪽 드래그 라면
                    else
                    {
                        transform.position = Vector3.Lerp(gameObject.transform.position, new Vector2(10, 0), speed * 0.01f);
                        Invoke("Mm", 1f);
                    }

                    maxY = 0;
                }
                else // 세로 드래그 라면
                {
                    // 아래 드래그 라면
                    if (touchDeltaPosition.y < 0)
                    {
                        // 대각선 아래-왼쪽 드래그 라면
                        if (touchDeltaPosition.x < 0)
                        {
                            transform.position = Vector3.Lerp(gameObject.transform.position, new Vector2(-10, -5), speed * 0.01f);
                            Invoke("Mm", 1f);
                        }
                        // 대각선 아래-오른쪽 드래그 라면
                        else
                        {
                            transform.position = Vector3.Lerp(gameObject.transform.position, new Vector2(10, -5), speed * 0.01f);
                            Invoke("Mm", 1f);
                        }
                    }
                    // 위쪽 드래그 라면
                    else
                    {
                        // 대각선 위쪽-왼쪽 드래그 라면
                        if (touchDeltaPosition.x < 0)
                        {
                            transform.position = Vector3.Lerp(gameObject.transform.position, new Vector2(-10, 5), speed * 0.01f);
                            Invoke("Mm", 1f);
                        }
                        // 대각선 위쪽-오른쪽 드래그 라면
                        else
                        {
                            transform.position = Vector3.Lerp(gameObject.transform.position, new Vector2(10, 5), speed * 0.01f);
                            Invoke("Mm", 1f);
                        }
                    }

                    maxX = 0;
                }
            }
        }
    }
}