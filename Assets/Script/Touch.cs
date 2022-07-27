using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;

public class Touch : MonoBehaviour
{
    public Light2D[] lights;
    public Text touchText;
    public Text inputText;
    public Text XYText;
    private Vector2[] touch = new Vector2[10];
    private CircleCollider2D _circleColliderChildren;
    private float sizeY;
    private float sizeX;
    private int index;
    private float temp = 0.25f;
    public Slider slider;

    private void Start()
    {
        _circleColliderChildren = GetComponentInChildren<CircleCollider2D>();
        sizeY = Screen.height / 3.0f;
        sizeX = Screen.width / 2.0f;
        XYText.text = "X : " + sizeX.ToString() + ' ' + Screen.width.ToString() + "\nY : " + sizeY.ToString() + ' ' + Screen.height.ToString();
    }

    void Update()
    {
        temp = slider.value + 0.5f;
        index = -1;
        for (int i = 0; i < Input.touchCount; i++)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                touch[i] = Input.GetTouch(i).position;


                if (touch[i].x > sizeX)
                    index = 3;
                else
                    index = 0;

                if (touch[i].y <= sizeY)
                    index += 0;
                else if (touch[i].y <= sizeY + sizeY)
                    index += 1;
                else
                    index += 2;

                //lights[index].intensity = 2.5f;
            }
        }

        for (int i = 0; i < lights.Length; i++)
        {
            if (lights[i].intensity > 0)
                lights[i].intensity -= Time.deltaTime;
            if (lights[i].intensity < 0)
                lights[i].intensity = 0;
        }

        touchText.text = touch[0].ToString();
        inputText.text = temp.ToString();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Line" + index) && collision.GetComponent<Enemy>())
        {
            Enemy _enemy = collision.GetComponent<Enemy>();
            Vector3 distance = -collision.transform.position;
            float temp = Mathf.Sqrt(distance.x * distance.x + distance.y * distance.y);

            if (temp >= _circleColliderChildren.radius + temp)
            {
                _enemy._spriteRenderer.sprite = _enemy.sprites[0];
                _enemy._spriteRenderer.color = Color.blue;
            }
            else if (temp >= _circleColliderChildren.radius + temp * 2)
            {
                _enemy._spriteRenderer.sprite = _enemy.sprites[1];
                _enemy._spriteRenderer.color = Color.green;
                
            }
            else
            {
                _enemy._spriteRenderer.sprite = _enemy.sprites[2];
                _enemy._spriteRenderer.color = Color.red;
            }

            _enemy.Dead();
        }
    }
}
