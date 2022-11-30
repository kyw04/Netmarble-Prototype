using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Touch : MonoBehaviour
{
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

                int mask = 1 << LayerMask.NameToLayer("Note");
                RaycastHit2D hit = Physics2D.Raycast(Vector2.zero, _spawner.pos[index].position, distance, mask);
                if (hit)
                {
                    //Debug.Log("hit!");
                    Note note = hit.collider.GetComponent<Note>();
                    if (index != -1 && hit.collider.gameObject.CompareTag("Line" + index) && note)
                    {
                        //Debug.Log(hit.collider.name);
                        if (note.noteType == Note.Type.Double && !note.isDead)
                        {
                            //Debug.Log("double note touch");
                            note.isTouch = true;
                            note.coolTime = Time.time + note.touchDelay;
                            if (!note._secondNote.isTouch) continue;
                        }
                        Vector3 direction = -hit.collider.transform.position;
                        float distance = Mathf.Sqrt(direction.x * direction.x + direction.y * direction.y);
                        distance = Mathf.Abs(distance);

                        if (distance > perfectRadius + errorRange + 1.5f)
                        {
                            Judgment.Instance.JudgmentChange(Judgment.Type.Bad);
                        }
                        else if (distance > perfectRadius + errorRange)
                        {
                            Judgment.Instance.JudgmentChange(Judgment.Type.Good);
                        }
                        else if (distance <= perfectRadius + errorRange && distance >= perfectRadius - errorRange)
                        {
                            Judgment.Instance.JudgmentChange(Judgment.Type.Perfect);
                        }
                        else
                        {
                            Judgment.Instance.JudgmentChange(Judgment.Type.Bad);
                        }

                        if (note.noteType == Note.Type.Double && note.isTouch && note._secondNote.isTouch)
                        {
                            note._secondNote.Dead();
                        }

                        note.Dead();
                    }
                }
            }
        }
        Debug.DrawRay(Vector3.zero, _spawner.pos[0].position * distance, Color.red);
        Debug.DrawRay(Vector3.zero, _spawner.pos[1].position * distance, Color.blue);
        Debug.DrawRay(Vector3.zero, _spawner.pos[2].position * distance, Color.yellow);
        Debug.DrawRay(Vector3.zero, _spawner.pos[3].position * distance, Color.green);
        Debug.DrawRay(Vector3.zero, _spawner.pos[4].position * distance, Color.cyan);
        Debug.DrawRay(Vector3.zero, _spawner.pos[5].position * distance, Color.gray);
        }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(1);
        if (collision.GetComponent<Note>())
        {
            Judgment.Instance.JudgmentChange(Judgment.Type.Bad);
            Note note = collision.GetComponent<Note>();
            note.Dead();
        }
    }
}
