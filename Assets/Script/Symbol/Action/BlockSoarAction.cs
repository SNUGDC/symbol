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

    public GameObject prefab;

    void Start()
    {
        //prefab = (GameObject)Resources.Load("Prefab/Game/Object/Cube", typeof(GameObject));
    }

    public override void Action()
    {
        GameObject instance = (GameObject)Instantiate(prefab, from, Quaternion.identity);
        switch (direction)
        {
            case eDirection.x:
                SoarX(instance, duration);
                break;
            case eDirection.y:
                SoarY(instance, duration);
                break;
            case eDirection.z:
                SoarZ(instance, duration);
                break;
        }
    }
    protected void SoarX(GameObject instance, float second)
    {
        iTween.ScaleTo(instance, new Vector3(length, 1, 1), second);
        iTween.MoveTo(instance, from + Vector3.right * length / 2.0f, second);
    }
    protected void SoarY(GameObject instance, float second)
    {
        iTween.ScaleTo(instance, new Vector3(1, length, 1), second);
        iTween.MoveTo(instance, from + Vector3.up * length / 2.0f, second);
    }
    protected void SoarZ(GameObject instance, float second)
    {
        iTween.ScaleTo(instance, new Vector3(1, 1, length), second);
        iTween.MoveTo(instance, from + Vector3.forward * length / 2.0f, second);
    }
}