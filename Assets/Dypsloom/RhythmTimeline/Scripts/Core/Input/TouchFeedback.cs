using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchFeedback : MonoBehaviour
{
    private IEnumerator enumerator;
    private GameObject child;
    public float inactiveTime = 0.5f;

    public void Start()
    {
        child = gameObject.transform.GetChild(0).gameObject;
        child.SetActive(false);
        enumerator = null;
    }

    public void TouchFeedbackStart()
    {
        if (enumerator == null)
        {
            enumerator = TouchFeedbackActive(inactiveTime);
            StartCoroutine(enumerator);
        }
    }

    private IEnumerator TouchFeedbackActive(float t)
    {
        child.SetActive(true);
        yield return new WaitForSeconds(t);
        child.SetActive(false);
        enumerator = null;
    }
}
