using System.Collections;
using UnityEngine;

public class AppearObjectAction : SymbolAction
{
    public GameObject prefab;
    public Vector3 position;
    public Vector3 rotation;

    public override void Action()
    {
        StartCoroutine(CreateInstance(duration));
    }

    private IEnumerator CreateInstance(float second)
    {
        yield return new WaitForSeconds(second);
        Instantiate(prefab, position, Quaternion.Euler(rotation));
    }
}