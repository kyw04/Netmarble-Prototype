using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public Transform[] pos;
    public float time;
    private int index;
    void Start()
    {
        StartCoroutine("Spawn");
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(time);

        index = Random.Range(0, pos.Length);
        GameObject newEnemy = Instantiate(enemy, pos[index].position, Quaternion.identity);
        newEnemy.gameObject.tag = "Line" + index.ToString();

        StartCoroutine("Spawn");
    }
}
