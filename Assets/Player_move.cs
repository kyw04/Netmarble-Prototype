using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime;
/*using System.Runtime.Remoting.Services;*/
using UnityEngine;
using UnityEngine.UI;

public class Player_move : MonoBehaviour
{

    SpriteRenderer spriteRenderer;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount >= 1)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).position - Input.GetTouch(0).rawPosition;

            if (touchDeltaPosition.x > 0)
            {
                if (touchDeltaPosition.y > 0)
                {
                    anim.SetBool("isOne", true);
                    spriteRenderer.flipX = true;
                }
                else if (touchDeltaPosition.y < 0)
                {
                    anim.SetBool("isThree", true);
                    spriteRenderer.flipX = true;
                }
            }
            else if (touchDeltaPosition.x < 0)
            {
                if (touchDeltaPosition.y > 0)
                {
                    anim.SetBool("isOne", true);
                }
                else if (touchDeltaPosition.y < 0)
                {
                    anim.SetBool("isThree", true);
                }
            }
        }
    }
}
