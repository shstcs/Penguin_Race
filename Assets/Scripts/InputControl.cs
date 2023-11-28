using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputControl : CharacterControl
{
    private Animator animator;
    private Camera _camera;
    Vector2 move;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        _camera = Camera.main;
    }
    public void OnMove(InputValue value)
    {
        move = value.Get<Vector2>().normalized;
        CallMoveEvent(move);
    }

    public void OnLook(InputValue value)
    {
        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPos = _camera.ScreenToWorldPoint(newAim);
        newAim = (worldPos - (Vector2)transform.position).normalized;
        if(newAim.magnitude > .9f)
        {
            CallLookEvent(newAim);
        }
    }

    public void OnAttack(InputValue value)
    {
        if (value.isPressed)
        {
            animator.SetBool("isAttack", true);
        }
        else
        {
            animator.SetBool("isAttack", false);
        }
    }

    public void OnJump(InputValue value)
    {
        if(value.isPressed)
        {
            animator.SetBool("isJump", true);
        }
        else
        {
            animator.SetBool("isJump", false);
        }
    }
    public void OnSlide(InputValue value)
    {
        if(value.isPressed)
        {
            animator.SetBool("isSlide", true);
            animator.SetBool("isRun", true);
        }
        else
        {
            animator.SetBool("isSlide", false);
            animator.SetBool("isRun", false);
        }
    }

    public void OnSpeak(InputValue value)
    {
        CallSpeakEvent();
    }

    private void Update()
    {
        if (move.magnitude > 0)
        {
            animator.SetBool("isWalk", true);
        }
        else
        {
            animator.SetBool("isWalk", false);
        }

        //HandleJumpDelay();
        //HandleAttackDelay();
        //HandleSlideDelay();
    }
    //private void HandleJumpDelay()
    //{
    //    if (_timeSinceLastJump <= .5f)
    //    {
    //        _timeSinceLastJump += Time.deltaTime;
    //    }
    //    else if (animator.GetBool("isJump"))
    //    {
    //        _timeSinceLastJump = 0f;
    //        CallJumpEvent();
    //    }
    //}
    //private void HandleSlideDelay()
    //{
    //    if (_timeSinceLastSlide <= 1f)
    //    {
    //        _timeSinceLastSlide += Time.deltaTime;
    //    }
    //    else if (animator.GetBool("isSlide"))
    //    {
    //        _timeSinceLastSlide = 0f;
    //        CallSlideEvent();
    //    }
    //}
    //private void HandleAttackDelay()
    //{
    //    if (_timeSinceLastAttack <= .3f)
    //    {
    //        _timeSinceLastAttack += Time.deltaTime;
    //    }
    //    else if (animator.GetBool("isAttack"))
    //    {
    //        _timeSinceLastAttack = 0f;
    //        CallAttackEvent();
    //    }
    //}

}
