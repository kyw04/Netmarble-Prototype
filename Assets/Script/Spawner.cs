using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemy;
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
        SpawnEnemy();
        StartCoroutine("Spawn");
    }

    private void SpawnEnemy()
    {
        int enemyIndex = Random.Range(0, enemy.Length);
        index = Random.Range(0, pos.Length);


        if (enemyIndex == 0)
        {
            GameObject newEnemy = Instantiate(enemy[enemyIndex], pos[index].position, Quaternion.identity);
            newEnemy.gameObject.tag = "Line" + index.ToString();
        }
        else if (enemyIndex == 1)
        {
            GameObject newEnemy = Instantiate(enemy[enemyIndex], pos[index].position, Quaternion.identity);
            newEnemy.gameObject.tag = "Line" + index.ToString();

            int minindex, maxIndex;
            if (index >= 3)
            {
                minindex = 0;
                maxIndex = 3;
            }
            else
            {
                minindex = 3;
                maxIndex = pos.Length;
            }
            index = Random.Range(minindex, maxIndex);
            GameObject newEnemy2 = Instantiate(enemy[enemyIndex], pos[index].position, Quaternion.identity);
            newEnemy.gameObject.tag = "Line" + index.ToString();
        }
    }
}
