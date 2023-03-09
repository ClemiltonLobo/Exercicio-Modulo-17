using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SOInt : ScriptableObject
{
    public int value;

    public event Action<int> onValueChanged;

    public void SetValue(int newValue)
    {
        value = newValue;

        if (onValueChanged != null)
        {
            onValueChanged(value);
        }
    }
}
