using System.Collections;
using UnityEngine;

public class LightOnAction : SymbolAction
{
    public Color changedColor = Color.white;
    public float addedIntensity = 1.5f;
    public override void Action()
    {
        Light[] lights = (Light[])FindObjectsOfType(typeof(Light));
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].intensity += addedIntensity;
            lights[i].color = changedColor;
        }
        if (duration > 0)
            StartCoroutine(revertLight(duration));
    }
    private IEnumerator revertLight(float time)
    {
        yield return new WaitForSeconds(time);
        Light[] lights = (Light[])FindObjectsOfType(typeof(Light));
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].intensity -= addedIntensity;
            lights[i].color = Color.white;
        }
    }
}