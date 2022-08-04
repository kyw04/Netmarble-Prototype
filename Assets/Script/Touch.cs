using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;

public class Touch : MonoBehaviour
{
    public Light2D[] _lights;
    public float perfectRadius;
    private Vector2[] touch = new Vector2[10];
    private float sizeY;
    private float sizeX;
    private float errorRange;
    private int index;

    private void Start()
    {
        errorRange = 0.5f;
        sizeY = Screen.height / 3.0f;
        sizeX = Screen.width / 2.0f;
    }

    void Update()
    {
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

                _lights[index].intensity = 2.5f;
            }
        }

        for (int i = 0; i < _lights.Length; i++)
        {
            if (_lights[i].intensity > 0)
                _lights[i].intensity -= Time.deltaTime;
            if (_lights[i].intensity < 0)
                _lights[i].intensity = 0;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Enemy _enemy = collision.GetComponent<Enemy>();
        if (index != -1 && collision.gameObject.CompareTag("Line" + index) && _enemy)
        {
            if (_enemy.nodeType == Enemy.Type.Double && !_enemy.isDead)
            {
                _enemy.isTouch = true;
                _enemy.coolTime = Time.time + _enemy.touchDelay;
                if (!_enemy._secondNode.isTouch) return;
            }
            Vector3 direction = -collision.transform.position;
            float distance = Mathf.Sqrt(direction.x * direction.x + direction.y * direction.y);
            distance = Mathf.Abs(distance);

            if (distance > perfectRadius + errorRange)
            {
                _enemy._spriteRenderer.sprite = _enemy._sprites[0];
                _enemy._spriteRenderer.color = Color.blue;
            }
            else if (distance <= perfectRadius + errorRange && distance >= perfectRadius - errorRange)
            {
                _enemy._spriteRenderer.sprite = _enemy._sprites[1];
                _enemy._spriteRenderer.color = Color.green;
            }
            else
            {
                _enemy._spriteRenderer.sprite = _enemy._sprites[2];
                _enemy._spriteRenderer.color = Color.red;
            }

            if (_enemy.nodeType == Enemy.Type.Double && _enemy.isTouch && _enemy._secondNode.isTouch)
            {
                _enemy._secondNode._spriteRenderer.sprite = _enemy._spriteRenderer.sprite;
                _enemy._secondNode._spriteRenderer.color = _enemy._spriteRenderer.color;

                _enemy._secondNode.Dead();
            }

            _enemy.Dead();
        }
    }
}
