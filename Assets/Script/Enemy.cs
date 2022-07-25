using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }

    private void Dead()
    {
        gameObject.layer = 8;
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<ParticleSystem>().Play();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Dead();
        }
    }
}
