﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpSpeed = 10f;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            Jump();

        if (Input.GetKeyDown(KeyCode.A))
            Grow();

        if (Input.GetKeyDown(KeyCode.Z))
            Shrink();

        transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, 0) * Time.deltaTime * moveSpeed;
    }

    void Jump()
    {
        rb.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
    }
    void Grow()
    {
        rb.transform.localScale += new Vector3(1, 1, 0);
    }

    void Shrink()
    {
        if (rb.transform.localScale.x != 1)
        {
            rb.transform.localScale += new Vector3(-1, -1, 0);
        }
    }
}
