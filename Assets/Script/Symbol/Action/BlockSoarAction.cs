using System.Collections;
using UnityEngine;

public enum eDirection
{
    x,
    y,
    z
}

public class BlockSoarAction : SymbolAction
{
    public Vector3 from;
    public eDirection direction;
    public float length;

    private GameObject cube;

    void Start()
    {
        cube = (GameObject)Resources.Load("Prefab/Game/Object/Cube", typeof(GameObject));
    }

    public override void Action()
    {
        GameObject instance = (GameObject)Instantiate(cube, from, Quaternion.identity);
        switch (direction)
        {
            case eDirection.x:
                iTween.ScaleTo(instance, new Vector3(length, 1, 1), duration);
                iTween.MoveTo(instance, from + Vector3.right * length / 2.0f, duration);
                break;
            case eDirection.y:
                iTween.ScaleTo(instance, new Vector3(1, length, 1), duration);
                iTween.MoveTo(instance, from + Vector3.up * length / 2.0f, duration);
                break;
            case eDirection.z:
                iTween.ScaleTo(instance, new Vector3(1, 1, length), duration);
                iTween.MoveTo(instance, from + Vector3.forward * length / 2.0f, duration);
                break;
        }
    }
}