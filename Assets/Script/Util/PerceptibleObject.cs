using System;
using System.Collections;
using UnityEngine;

public abstract class PerceptibleObject : MonoBehaviour
{
    public abstract bool isTouchable();
    public abstract Type getReceiverType();
}