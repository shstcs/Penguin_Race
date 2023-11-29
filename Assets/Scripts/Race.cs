using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Race : MonoBehaviour
{
    public bool isRacing { get; set; }
    protected float curRecord;
    protected float bestRecord = float.MaxValue;
    protected event Action isRacingStart;
    protected event Action isRacingEnd;

    public void CallRacingStart()
    {
        isRacingStart?.Invoke();
    }
    public void CallRacingEnd()
    {
        isRacingEnd?.Invoke();
    }
    public void SetisRacing(bool value)
    {
        isRacing = value;
    }
}
