using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DayProgression : MonoBehaviour
{
    public UnityEvent OnDayAdvanced;
    public void advanceDay()
    {
        OnDayAdvanced?.Invoke();
    }
}
