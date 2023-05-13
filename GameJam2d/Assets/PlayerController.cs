using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using InputTools;

public class PlayerController : MonoBehaviour
{
    OverworldActionMap inputs;

    public float speed;
    public Rigidbody2D rb;
    public float maxSpeed;

    private void OnEnable()
    {
        inputs = new OverworldActionMap();
    }
    private void OnDisable()
    {
        inputs.Disable();
    }

    private void FixedUpdate()
    {
        Vector2 rawInput = inputs.movement.ReadValue<Vector2>();

        rb.velocity += rawInput;
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed), Mathf.Clamp(rb.velocity.y, -maxSpeed, maxSpeed));
    }
}
