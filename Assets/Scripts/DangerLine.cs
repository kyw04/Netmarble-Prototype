using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerLine : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    public float speed;
    public float scale;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(ShowRange());
    }

    private IEnumerator ShowRange()
    {
        float n = Camera.main.sensorSize.x;
        yield return StartCoroutine(ScaleChange(n, 0.75f));
        yield return new WaitForSeconds(0.25f);

        gameObject.layer = 8;
        _spriteRenderer.color = Color.red;
        speed *= 0.01f;

        yield return StartCoroutine(ScaleChange(n, 0.25f));
        Destroy(gameObject);
    }

    private IEnumerator ScaleChange(float n, float time)
    {
        Vector3 startPosition = transform.position;
        Vector3 startScale = transform.localScale;

        while (transform.localScale.x < n)
        {
            transform.localScale += new Vector3(scale, 0, 0) * Time.deltaTime;
            transform.position += transform.right * scale / 2 * Time.deltaTime;
            yield return new WaitForSeconds(speed);
        }

        yield return new WaitForSeconds(time);
        transform.localScale = startScale;
        transform.position = startPosition;
        yield return new WaitForSeconds(0.25f);
    }
}
