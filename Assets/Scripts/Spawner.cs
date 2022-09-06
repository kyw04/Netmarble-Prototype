using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private Sprite[] bigNoteHitBoxSprite;
    [SerializeField]
    private Sprite[] bigNoteMarkSprite;

    private TextReader reader;
    public Move move;
    public MusicManager musicManager;
    public string[] noteName;
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
                    _time = 3.15f;

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
                SpawnBigNote();
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
        GameObject newNote = ObjectPool.Instance.MakeObject(noteName[index]);
        Note noteScript = newNote.GetComponent<Note>();
        newNote.transform.position = pos[positionIndex].position;
        newNote.transform.rotation = Quaternion.identity;
        newNote.gameObject.tag = "Line" + positionIndex.ToString();
        noteScript.moveDirection = -pos[positionIndex].position;
        noteScript.moveDirection = noteScript.moveDirection.normalized;

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

    private void SpawnBigNote()
    {
        int index = Random.Range(0, 6);
        Vector2 direction = Vector2.zero;

        switch (index)
        {
            case 0: // 왼쪽 
            case 1: // 왼쪽 아래
            case 2: // 왼쪽 위
                direction = new Vector2(1, 0);
                break;
            case 3: // 오른쪽
            case 4: // 오른쪽 아래
            case 5: // 오른쪽 위
                direction = new Vector2(-1, 0);
                break;
        }


        GameObject newNote = ObjectPool.Instance.MakeObject(noteName[3]);
        newNote.transform.position = Vector3.zero;
        newNote.transform.localScale = Camera.main.sensorSize / 1.5f;
        BigNote newNoteBig = newNote.GetComponent<BigNote>();
        newNoteBig.direction = direction;

        newNoteBig.hitBoxRenderer.material.mainTextureOffset = direction;
        newNoteBig.markRenderer.material.mainTextureOffset = direction;

        newNote.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = bigNoteHitBoxSprite[index];
        newNote.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = bigNoteMarkSprite[index];
    }
}
