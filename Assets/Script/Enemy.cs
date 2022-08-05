using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum Type 
    { 
        None,
        Single,
        Double
    }
    public Type nodeType;
    private ParticleSystem _particleSystem;
    public Enemy _secondNode;
    public SpriteRenderer _spriteRenderer;
    public Sprite[] _sprites;
    public float speed;
    public float coolTime;
    public float touchDelay;
    public bool isDead;
    public bool isTouch;

    private Vector3 moveDirection;

    private void Start()
    {
        isTouch = false;
        isDead = false;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _particleSystem = GetComponent<ParticleSystem>();

        moveDirection = -transform.position;
        moveDirection = moveDirection.normalized;
    }

    void Update()
    {
        if (!isDead)
        {
            transform.position += moveDirection * speed * Time.deltaTime;

            if (isTouch && Time.time >= coolTime)
            {
                isTouch = false;
            }
        }
    }

    public void Dead()
    {
        if (!isDead)
        {
            isDead = true;
            gameObject.layer = 8;
            _particleSystem.Play();

            StartCoroutine(Transparency());

            Destroy(this.gameObject, 2f);
        }
    }
    
    private IEnumerator Transparency()
    {
        yield return new WaitForSeconds(1f);

        while (_spriteRenderer.color.a > 0)
        {
            _spriteRenderer.color -= new Color32(0, 0, 0, 1);
            yield return new WaitForSeconds(0.001f);
        }
    }
}
