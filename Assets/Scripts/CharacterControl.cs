using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action OnAttackEvent;
    public event Action OnJumpEvent;
    public event Action OnSlideEvent;
  
    public void CallMoveEvent(Vector2 move)
    {
        OnMoveEvent?.Invoke(move);
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }

    public void CallAttackEvent()
    {
        OnAttackEvent?.Invoke();
    }

    public void CallJumpEvent()
    {
        OnJumpEvent?.Invoke();
    }

    public void CallSlideEvent()
    {
        OnSlideEvent?.Invoke();
    }
}
