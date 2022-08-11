using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] node;
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

        StartCoroutine("Spawn");
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(time);
        Spawnnode();
        StartCoroutine("Spawn");
    }

    private void Spawnnode()
    {
        int nodeIndex = Random.Range(0, node.Length);
        positionIndex = Random.Range(0, pos.Length);


        if (nodeIndex == 0)
        {
            CreateNode(nodeIndex);
        }
        else if (nodeIndex == 1)
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

            CreateNode(nodeIndex, minIndex, maxIndex);
        }
    }

    private GameObject CreateNode(int index)
    {

        GameObject newNode = Instantiate(node[index], pos[positionIndex].position, Quaternion.identity);
        newNode.gameObject.tag = "Line" + positionIndex.ToString();
        newNode.transform.LookAt(Vector3.zero);

        return newNode;
    }
    private GameObject CreateNode(int index, int minIndex, int maxIndex)
    {
        GameObject newNode1 = CreateNode(index);
        positionIndex = Random.Range(minIndex, maxIndex);
        GameObject newNode2 = CreateNode(index);

        newNode1.GetComponent<Node>()._secondNode = newNode2.GetComponent<Node>();
        newNode2.GetComponent<Node>()._secondNode = newNode1.GetComponent<Node>();

        return newNode2;
    }
}
