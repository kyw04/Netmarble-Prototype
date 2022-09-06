using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public enum Type 
    { 
        None,
        Single,
        Double
    }
    public Type noteType;
    private ParticleSystem _particleSystem;
    public Note _secondNote;
    public SpriteRenderer _spriteRenderer;
    public Sprite[] _sprites;
    public float speed;
    public float coolTime;
    public float touchDelay;
    public bool isDead;
    public bool isTouch;
    
    [HideInInspector]
    public Vector3 moveDirection;

    //public float finishTime = 0;

    private void OnEnable() { Start(); }
    private void Start()
    {
        isTouch = false;
        isDead = false;
        gameObject.layer = 7;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _particleSystem = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (!isDead)
        {
            transform.position += moveDirection * speed * Time.deltaTime;
            //finishTime += Time.deltaTime;

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
            //Debug.Log(finishTime);
            isDead = true;
            gameObject.layer = 8;
            _particleSystem.Play();

            ObjectPool.Instance.DestroyObject(this.gameObject, 2f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            _spriteRenderer.sprite = _sprites[2];
            Dead();
        }
    }
}
