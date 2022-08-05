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
        //float a = Vector3.zero.x - pos[1].position.x;
        //float b = pos[1].position.y - pos[2].position.y;
        //float c = Mathf.Sqrt(a * a + b * b);

        //Debug.Log(a);
        //Debug.Log(c);
        //Debug.Log(a - c);

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
            newEnemy2.gameObject.tag = "Line" + index.ToString();

            newEnemy.GetComponent<Enemy>()._secondNode = newEnemy2.GetComponent<Enemy>();
            newEnemy2.GetComponent<Enemy>()._secondNode = newEnemy.GetComponent<Enemy>();
        }
    }
}
