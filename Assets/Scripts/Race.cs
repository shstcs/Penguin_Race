using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Race : MonoBehaviour
{
    protected bool isRacing = false;
    protected float curRecord;
    protected float bestRecord = float.MaxValue;
    protected event Action isRacingStart;
    protected event Action isRacingEnd;

    public void CallRacingStart()
    {
        isRacing = true;
        isRacingStart?.Invoke();
    }
    public void CallRacingEnd()
    {
        isRacing = false;
        isRacingEnd?.Invoke();
    }
}
