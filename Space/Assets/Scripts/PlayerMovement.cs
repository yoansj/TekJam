using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public bool canJump = true;

    private CharacterController2D control;
    private float horizontal = 0f;

    [HideInInspector]
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        control = GetComponent<CharacterController2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            Jump();

        horizontal = Input.GetAxisRaw("Horizontal") * moveSpeed;
    }

    void FixedUpdate()
    {
        control.Move(horizontal * Time.deltaTime, false, false);
    }

    void Jump()
    {
        if (canJump)
        {
            rb.MovePosition(transform.position + new Vector3(0, jumpForce * Time.deltaTime));
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            canJump = false;
        }
    }
}