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
    public float maxSpeed;

    Rigidbody2D rb;

    SpriteAnimator animator;
    Vector3 originalVectorScale;

    [SerializeField] float hp;
    public float Hp
    {
        get
        {
            return hp;
        }
        set
        {
            hp = value;
            if(hp < 0)
            {
                hp = 0;
            }
            if(value == 0)
            {
                StartCoroutine(Die());
            }
        }
    }

    private void Awake()
    {
        animator = GetComponent<SpriteAnimator>();
        rb = GetComponent<Rigidbody2D>();
        animator.Init();
        originalVectorScale = transform.localScale;
    }

    private void OnEnable()
    {
        inputs = new OverworldActionMap();
        inputs.interact.performed += ctx => Interact();
    }
    private void OnDisable()
    {
        inputs.Disable();
    }

    private void FixedUpdate()
    {
        Vector2 rawInput = inputs.movement.ReadValue<Vector2>();
        if(hp > 0)
        {
            rb.velocity += rawInput * new Vector2(speed,speed);
            rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed), Mathf.Clamp(rb.velocity.y, -maxSpeed, maxSpeed));

            if (rb.velocity.x < 0)
            {
                transform.localScale = new Vector3(-originalVectorScale.x, originalVectorScale.y, originalVectorScale.z);
            }
            else if (rb.velocity.x > 0)
            {
                transform.localScale = originalVectorScale;
            }
            if (Mathf.Abs(rawInput.x + rawInput.y) > 0)
            {
                animator.PlayAnim(AnimatorState.Moving);
            }
            else
            {
                animator.StopAnim();
            }
        }
        animator.UpdateSprite();
    }

    void Interact()
    {
        StartCoroutine(Die());
    }

    public IEnumerator Die()
    {
        hp = 0;
        Time.timeScale = .2f;
        animator.PlayAnim(AnimatorState.Dying);
        yield return new WaitUntil(animator.IsAnimFinished);
        Time.timeScale = 1;
    }
}
