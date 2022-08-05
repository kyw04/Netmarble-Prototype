using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;


public class Move : MonoBehaviour
{
    //public Slider speedSlider;
    public float speed;
    public float value;
    //bool inputRight = false;
    //bool inputLeft = false;


    void Start()
    {
        value = 0.5f;
    }

    void Mm()
    {
        transform.position = Vector3.Lerp(gameObject.transform.position, new Vector2(0, 0), speed * 0.01f);
    }



    void Update()
    {
        //speed = speedSlider.value * 1000;

        if (Input.touchCount >= 1)
        {
            //Touch touch = Input.GetTouch(0);
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            float maxX, maxY;

            if (touchDeltaPosition.x < 0)
                maxX = -touchDeltaPosition.x;
            else
                maxX = touchDeltaPosition.x;

            if (touchDeltaPosition.y < 0)
                maxY = -touchDeltaPosition.y;
            else
                maxY = touchDeltaPosition.y;


            if ((maxX >= value || maxY >= value) && Input.GetTouch(0).phase == TouchPhase.Ended)
                if (maxX > maxY)
                {
                    if (touchDeltaPosition.x < 0)
                    {
                        //inputLeft = true;
                        transform.position = Vector3.Lerp(gameObject.transform.position, new Vector2(-2, 0), speed * 0.01f);
                        Invoke("Mm", 1f);
                    }
                    else
                    {
                        //inputRight = true;
                        transform.position = Vector3.Lerp(gameObject.transform.position, new Vector2(2, 0), speed * 0.01f);
                        Invoke("Mm", 1f);
                    }

                    maxY = 0;


                }
                else
                {
                    if (touchDeltaPosition.y < 0)
                    {
                        if (touchDeltaPosition.x < 0)
                        {
                            transform.position = Vector3.Lerp(gameObject.transform.position, new Vector2(-2, -2), speed * 0.01f);
                            Invoke("Mm", 1f);
                        }
                        else
                        {
                            transform.position = Vector3.Lerp(gameObject.transform.position, new Vector2(2, -2), speed * 0.01f);
                            Invoke("Mm", 1f);
                        }
                    }
                    else
                    {
                        if (touchDeltaPosition.x < 0)
                        {
                            transform.position = Vector3.Lerp(gameObject.transform.position, new Vector2(-2, 2), speed * 0.01f);
                            Invoke("Mm", 1f);
                        }
                        else
                        {
                            transform.position = Vector3.Lerp(gameObject.transform.position, new Vector2(2, 2), speed * 0.01f);
                            Invoke("Mm", 1f);
                        }
                    }

                    maxX = 0;

                }            

        }

    }
}