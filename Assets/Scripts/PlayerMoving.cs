using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(CapsuleCollider2D))]
public class PlayerMoving : MonoBehaviour
{
    public float speed;
    public Joystick joystick;
    private Rigidbody2D rb;
    private Vector2 MoveVelocity;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        Vector2 moveInput = new Vector2(joystick.Horizontal, joystick.Vertical);
        MoveVelocity = moveInput.normalized * speed;
        if (joystick.Horizontal < 0)
        {
            transform.rotation = new Quaternion(0, 180, 0,0);
        }
        else if (joystick.Horizontal > 0)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + MoveVelocity * Time.deltaTime);
    }
}

