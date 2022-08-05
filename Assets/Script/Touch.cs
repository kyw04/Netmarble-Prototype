using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;

public class Touch : MonoBehaviour
{
    public Light2D[] _lights;
    public Spawner _spawner;
    public float perfectRadius;
    public float distance;
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
        for (int i = 0; i < Input.touchCount && i < 10; i++)
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

                int mask = 1 << LayerMask.NameToLayer("Enemy");
                RaycastHit2D hit = Physics2D.Raycast(Vector2.zero, _spawner.pos[index].position, distance, mask);
                if (hit)
                {
                    //Debug.Log("hit!");
                    Enemy _enemy = hit.collider.GetComponent<Enemy>();
                    if (index != -1 && hit.collider.gameObject.CompareTag("Line" + index) && _enemy)
                    {
                        Debug.Log(hit.collider.name);
                        if (_enemy.nodeType == Enemy.Type.Double && !_enemy.isDead)
                        {
                            //Debug.Log("double node touch");
                            _enemy.isTouch = true;
                            _enemy.coolTime = Time.time + _enemy.touchDelay;
                            if (!_enemy._secondNode.isTouch) continue;
                        }
                        Vector3 direction = -hit.collider.transform.position;
                        float distance = Mathf.Sqrt(direction.x * direction.x + direction.y * direction.y);
                        distance = Mathf.Abs(distance);

                        if (distance > perfectRadius + errorRange + 1.5f)
                        {
                            _enemy._spriteRenderer.sprite = _enemy._sprites[0];
                            _enemy._spriteRenderer.color = Color.black;
                        }
                        else if (distance > perfectRadius + errorRange)
                        {
                            _enemy._spriteRenderer.sprite = _enemy._sprites[1];
                            _enemy._spriteRenderer.color = Color.blue;
                        }
                        else if (distance <= perfectRadius + errorRange && distance >= perfectRadius - errorRange)
                        {
                            _enemy._spriteRenderer.sprite = _enemy._sprites[2];
                            _enemy._spriteRenderer.color = Color.green;
                        }
                        else
                        {
                            _enemy._spriteRenderer.sprite = _enemy._sprites[3];
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
                //Debug.Log(index);
                //_lights[index].intensity = 2.5f;
            }
        }
        Debug.DrawRay(Vector3.zero, _spawner.pos[0].position * distance, Color.red);
        Debug.DrawRay(Vector3.zero, _spawner.pos[1].position * distance, Color.blue);
        Debug.DrawRay(Vector3.zero, _spawner.pos[2].position * distance, Color.yellow);
        Debug.DrawRay(Vector3.zero, _spawner.pos[3].position * distance, Color.green);
        Debug.DrawRay(Vector3.zero, _spawner.pos[4].position * distance, Color.cyan);
        Debug.DrawRay(Vector3.zero, _spawner.pos[5].position * distance, Color.gray);

        for (int i = 0; i < _lights.Length; i++)
        {
            if (_lights[i].intensity > 0)
                _lights[i].intensity -= Time.deltaTime;
            if (_lights[i].intensity < 0)
                _lights[i].intensity = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            Enemy _enemy = collision.GetComponent<Enemy>();
            _enemy._spriteRenderer.sprite = _enemy._sprites[2];
            _enemy._spriteRenderer.color = Color.red;
            _enemy.Dead();
        }
    }
}
