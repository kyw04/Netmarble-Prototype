using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Move : MonoBehaviour
{
    //public Slider speedSlider;
    public float speed;
    public float value;
    float maxX, maxY;

    void Start()
    {
        value = 10f;
    }

    // ���ڸ� ��ġ ����
    void Mm()
    {
        transform.position = Vector3.Lerp(gameObject.transform.position, new Vector2(0, 0), speed * 0.01f);
    }

    void Update()
    {
        speed = value * 1000;

        if (Input.touchCount >= 1)
        {

            //Touch touch = Input.GetTouch(0);
            //Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition; // ������ �κ� �ּ� ó����  
            Vector2 touchDeltaPosition = Input.GetTouch(0).position - Input.GetTouch(0).rawPosition; // ������ �ڵ� �߰� 

            // ����, ���� �Ÿ��� ���밪
            if (touchDeltaPosition.x < 0)
                maxX = -touchDeltaPosition.x;
            else
                maxX = touchDeltaPosition.x;

            if (touchDeltaPosition.y < 0)
                maxY = -touchDeltaPosition.y;
            else
                maxY = touchDeltaPosition.y;

            // �巡�װ� �����ٸ�
            if ((maxX >= value || maxY >= value) && Input.GetTouch(0).phase == TouchPhase.Ended)
            {

                // ���� �巡�� ���
                if (maxX > maxY)
                {
                    // ���� �巡�� ���
                    if (touchDeltaPosition.x < 0)
                    {
                        transform.position = Vector3.Lerp(gameObject.transform.position, new Vector2(-15, -2), speed * 0.01f);
                        Invoke("Mm", 1f);
                    }
                    // ������ �巡�� ���
                    else
                    {
                        transform.position = Vector3.Lerp(gameObject.transform.position, new Vector2(18, -2), speed * 0.01f);
                        Invoke("Mm", 1f);
                    }

                    maxY = 0;
                }
                else // ���� �巡�� ���
                {
                    // �Ʒ� �巡�� ���
                    if (touchDeltaPosition.y < 0)
                    {
                        // �밢�� �Ʒ�-���� �巡�� ���
                        if (touchDeltaPosition.x < 0)
                        {
                            transform.position = Vector3.Lerp(gameObject.transform.position, new Vector2(-15, -10), speed * 0.01f);
                            Invoke("Mm", 1f);
                        }
                        // �밢�� �Ʒ�-������ �巡�� ���
                        else
                        {
                            transform.position = Vector3.Lerp(gameObject.transform.position, new Vector2(18, -10), speed * 0.01f);
                            Invoke("Mm", 1f);
                        }
                    }
                    // ���� �巡�� ���
                    else
                    {
                        // �밢�� ����-���� �巡�� ���
                        if (touchDeltaPosition.x < 0)
                        {
                            transform.position = Vector3.Lerp(gameObject.transform.position, new Vector2(-15, 6), speed * 0.01f);
                            Invoke("Mm", 1f);
                        }
                        // �밢�� ����-������ �巡�� ���
                        else
                        {
                            transform.position = Vector3.Lerp(gameObject.transform.position, new Vector2(18, 6), speed * 0.01f);
                            Invoke("Mm", 1f);
                        }
                    }

                    maxX = 0;
                }
            }
        }
    }
}