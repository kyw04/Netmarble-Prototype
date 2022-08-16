using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] note;
    public GameObject line;
    public Transform[] pos;
    public float time;
    private int positionIndex;
    void Start()
    {
        //float a = Vector3.zero.x - pos[1].position.x;
        //float b = pos[1].position.y - pos[2].position.y;
        //float c = Mathf.Sqrt(a * a + b * b);

        //Debug.Log(a);
        //Debug.Log(c);
        //Debug.Log(a - c);
        Debug.Log(Camera.main.sensorSize);

        StartCoroutine("Spawn");
    }

    private IEnumerator Spawn()
    {
        SpawnNote();
        //SpawnLine();
        yield return new WaitForSeconds(time);
        StartCoroutine("Spawn");
    }

    private void SpawnNote()
    {
        int noteIndex = Random.Range(0, note.Length);
        positionIndex = Random.Range(0, pos.Length);


        if (noteIndex == 0)
        {
            CreateNote(noteIndex);
        }
        else if (noteIndex == 1)
        {
            int minIndex, maxIndex;
            if (positionIndex >= 3)
            {
                minIndex = 0;
                maxIndex = 3;
            }
            else
            {
                minIndex = 3;
                maxIndex = pos.Length;
            }

            CreateNote(noteIndex, minIndex, maxIndex);
        }
    }

    private GameObject CreateNote(int index)
    {
        GameObject newNote = Instantiate(note[index], pos[positionIndex].position, Quaternion.identity);
        newNote.gameObject.tag = "Line" + positionIndex.ToString();

        return newNote;
    }
    private GameObject CreateNote(int index, int minIndex, int maxIndex)
    {
        GameObject newNote1 = CreateNote(index);
        positionIndex = Random.Range(minIndex, maxIndex);
        GameObject newNote2 = CreateNote(index);

        newNote1.GetComponent<Note>()._secondNote = newNote2.GetComponent<Note>();
        newNote2.GetComponent<Note>()._secondNote = newNote1.GetComponent<Note>();

        return newNote2;
    }

    private void SpawnLine()
    {
        int temp = Random.Range(-1, 1);
        Quaternion quaternion;
        if (temp == 0)
        {
            temp = 1;
            quaternion = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            quaternion = Quaternion.identity;
        }

        GameObject newLine = Instantiate(line, new Vector3(Camera.main.sensorSize.x * temp, 0, 0), quaternion);
        newLine.transform.localScale = Vector3.up * Camera.main.sensorSize;
    }
}
