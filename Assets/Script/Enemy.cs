using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private ParticleSystem _particleSystem;
    public SpriteRenderer _spriteRenderer;
    public Sprite[] sprites;
    public float speed;
    public bool isDead;

    private Vector3 moveDirection;

    private void Start()
    {
        isDead = false;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _particleSystem = GetComponent<ParticleSystem>();
    
        moveDirection = -transform.position;
        moveDirection = moveDirection.normalized;
    }

    void Update()
    {
        if (!isDead)
            transform.position += moveDirection * speed * Time.deltaTime;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _spriteRenderer.sprite = sprites[2];
            _spriteRenderer.color = Color.red;
            Dead();
        }
    }
}
