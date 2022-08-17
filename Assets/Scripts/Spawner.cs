using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private TextReader reader;
    public MusicManager musicManager;
    public GameObject[] note;
    public Transform[] pos;
    public float time;
    private int positionIndex;
    private int noteIndex;
    void Start()
    {
        reader = GetComponent<TextReader>();
        noteIndex = 0;

        StartCoroutine("Spawn");
    }

    private IEnumerator Spawn()
    {
        noteIndex++;

        if (noteIndex < reader.n)
        {
            time = reader.time[noteIndex];


            yield return new WaitForSeconds(time);

            if (musicManager.isPlaying == false)
            {
                float _time;
                if (PlayerPrefs.HasKey("WaitTime"))
                    _time = PlayerPrefs.GetFloat("WaitTime");
                else
                    _time = 5.523338f - 0.2767995f;

                StartCoroutine(musicManager.StartMusic(0, _time));
            }

            if (reader.type[noteIndex] == 0 || reader.type[noteIndex] == 1)
            {
                SpawnNote(reader.type[noteIndex]);
            }
            else if (reader.type[noteIndex] == 2)
            {

            }
            else if (reader.type[noteIndex] == 3)
            {
                SpawnLine();
            }

            StartCoroutine("Spawn");
        }
        else
        {
            yield return null;
        }
    }

    private void SpawnNote(int index)
    {
        positionIndex = Random.Range(0, pos.Length);


        if (index == 0)
        {
            CreateNote(index);
        }
        else if (index == 1)
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

            CreateNote(index, minIndex, maxIndex);
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

        GameObject newLine = Instantiate(note[3], new Vector3(Camera.main.sensorSize.x * temp, 0, 0), quaternion);
        newLine.transform.localScale = Vector3.up * Camera.main.sensorSize;
    }
}
