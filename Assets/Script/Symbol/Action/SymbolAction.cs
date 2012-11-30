using System.Collections;
using UnityEngine;

public abstract class SymbolAction : MonoBehaviour
{
    public float duration = -1.0f;
    public abstract void Action();

    public void PressSuccess()
    {
        Action();
    }
    public void PressReady()
    {
    }
    public void PressFailed()
    {
    }
}