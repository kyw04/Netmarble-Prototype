using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;

    public GameObject singleNotePrefab;
    public GameObject doubleNotePrefab;
    public GameObject bigNotePrefab;

    private GameObject[] singleNote;
    private GameObject[] doubleNote;
    private GameObject[] bigNote;

    private GameObject[] targetPool;

    private void Awake()
    {
        Instance = this;

        singleNote = new GameObject[32];
        doubleNote = new GameObject[64];
        bigNote = new GameObject[5];

        Generate();
    }

    private void Generate()
    {
        for (int i = 0; i < singleNote.Length; i++)
        {
            singleNote[i] = Instantiate(singleNotePrefab);
            singleNote[i].transform.SetParent(transform);
            singleNote[i].SetActive(false);
        }

        for (int i = 0; i < doubleNote.Length; i++)
        {
            doubleNote[i] = Instantiate(doubleNotePrefab);
            doubleNote[i].transform.SetParent(transform);
            doubleNote[i].SetActive(false);
        }

        for (int i = 0; i < bigNote.Length; i++)
        {
            bigNote[i] = Instantiate(bigNotePrefab);
            bigNote[i].transform.SetParent(transform);
            bigNote[i].SetActive(false);
        }
    }

    public GameObject MakeObject(string type)
    {
        switch (type)
        {
            case "SingleNote" :
                targetPool = singleNote;
                break;
            case "DoubleNote":
                targetPool = doubleNote;
                break;
            case "LongNote":
                break;
            case "BigNote":
                targetPool = bigNote;
                break;

            default:
                targetPool = null;
                break;
        }

        for (int i = 0; i < targetPool.Length; i++)
        {
            if (!targetPool[i].activeSelf)
            {
                targetPool[i].SetActive(true);
                return targetPool[i];
            }
        }

        return null;
    }

    public void DestroyObject(GameObject target, float time)
    {
        StartCoroutine(DestroyObjectImpl(target, time));
    }
    public void DestroyObject(GameObject target)
    {
        StartCoroutine(DestroyObjectImpl(target, 0));
    }

    private IEnumerator DestroyObjectImpl(GameObject target, float time)
    {
        yield return new WaitForSeconds(time);
        target.SetActive(false);
    }
}
