using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ingamecurtain : MonoBehaviour
{
    public Transform target1;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = Vector3.Lerp(gameObject.transform.position, target1.transform.position, 0.005f);
    }


}
