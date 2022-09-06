using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigNote : MonoBehaviour
{
    public Renderer hitBoxRenderer;
    public Renderer markRenderer;
    private bool markEnd;
    private bool hitBoxEnd;
    public float speed;

    [HideInInspector]
    public Vector2 direction;
    private void OnEnable() { Start(); }

    public void Start()
    {
        hitBoxRenderer.enabled = false;
        markRenderer.enabled = true;
        markEnd = false;
        hitBoxEnd = false;
    }

    private void Update()
    {
        if (!markEnd)
        {
            markRenderer.material.mainTextureOffset -= direction * speed * Time.deltaTime;

            if (markRenderer.material.mainTextureOffset.x * direction.x < 0)
            {
                markEnd = true;
                markRenderer.enabled = false;
                hitBoxRenderer.enabled = true;
            }
        }
        else if (!hitBoxEnd)
        {
            hitBoxRenderer.material.mainTextureOffset -= direction * speed * 2 * Time.deltaTime;
           
            if (hitBoxRenderer.material.mainTextureOffset.x * direction.x < 0)
            {
                hitBoxEnd = true;
            }
        }

        if (hitBoxEnd)
        {
            ObjectPool.Instance.DestroyObject(this.gameObject, 1f);
        }
    }
}
