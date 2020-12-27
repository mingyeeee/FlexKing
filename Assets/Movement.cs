﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb2d;
    BoxCollider2D boxCollider2D;

    public float velocity;
    public float jumpspeed;
    public float fallmultiplier = 2.5f;
    public float lowjumpmultiplayer = 2f;
    public float airspeed = 1f;
    [SerializeField] LayerMask platformlayer;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }


    private void FixedUpdate()
    {
        if (rb2d.velocity.y < 0)
        {
            rb2d.AddForce(Physics.gravity * rb2d.mass * fallmultiplier);
        }
        else if (rb2d.velocity.y > 0)
        {
            rb2d.AddForce(Physics.gravity * rb2d.mass * lowjumpmultiplayer);
        }

        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            if (isgrouded())
            {
                transform.localScale = new Vector3(1, 1, 1);
                rb2d.velocity = new Vector2(velocity, rb2d.velocity.y);
            }
            else
            {
                rb2d.velocity = new Vector2(airspeed, rb2d.velocity.y);
            }


        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            if (isgrouded())
            {
                transform.localScale = new Vector3(-1, 1, 1);
                rb2d.velocity = new Vector2(-velocity, rb2d.velocity.y);
            }
            else
            {
                rb2d.velocity = new Vector2(-airspeed, rb2d.velocity.y);
            }

        }


        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }

        if (isgrouded() && Input.GetKey("space"))
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpspeed);
        }

    }
    private bool isgrouded()
    {
        float extraheight = 0.1f;
        RaycastHit2D raycasthit = Physics2D.Raycast(boxCollider2D.bounds.center, Vector2.down, boxCollider2D.bounds.extents.y + extraheight, platformlayer);
        Debug.DrawRay(boxCollider2D.bounds.center, Vector2.down * (boxCollider2D.bounds.extents.y + extraheight), Color.green);
        return raycasthit.collider != null;
    }
}
