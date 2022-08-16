using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liness : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private Linerenderer line;

    private void Start()
    {
        line.SetUpLine(points); 
    }
}
