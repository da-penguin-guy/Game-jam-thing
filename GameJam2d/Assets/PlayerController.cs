using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using InputTools;
using System.Runtime;

public class PlayerController : MonoBehaviour
{
    OverworldActionMap inputs;

    public float speed;
    public Rigidbody2D rb;
    public float maxSpeed;
    SpriteAnimator animator;
    Vector3 originalVectorScale;

    private void Awake()
    {
        animator = GetComponent<SpriteAnimator>();
        originalVectorScale = transform.localScale;
    }

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
        
        if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-originalVectorScale.x, originalVectorScale.y, originalVectorScale.z);
        }
        else if (rb.velocity.x > 0)
        {
            transform.localScale = originalVectorScale;
        }
        if(Mathf.Abs(rawInput.x + rawInput.y) > 0)
        {
            animator.PlayAnim(AnimatorState.Moving);
        }
        animator.UpdateSprite();
    }
}
