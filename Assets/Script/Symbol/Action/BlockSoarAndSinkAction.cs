using System.Collections;
using UnityEngine;

public class BlockSoarAndSinkAction : BlockSoarAction
{
    public override void Action()
    {
        GameObject instance = (GameObject)Instantiate(prefab, from, Quaternion.identity);
        switch (direction)
        {
            case eDirection.x:
                SoarX(instance, duration / 2.0f);
                break;
            case eDirection.y:
                SoarY(instance, duration / 2.0f);
                break;
            case eDirection.z:
                SoarZ(instance, duration / 2.0f);
                break;
        }
        StartCoroutine(SinkReady(instance));
    }
    private IEnumerator SinkReady(GameObject instance)
    {
        yield return new WaitForSeconds(duration / 2.0f);
        Destroy(instance, duration / 2.0f);
        switch (direction)
        {
            case eDirection.x:
                SinkX(instance, duration);
                break;
            case eDirection.y:
                SinkY(instance, duration);
                break;
            case eDirection.z:
                SinkZ(instance, duration);
                break;
        }
    }
    protected void SinkX(GameObject instance, float second)
    {
        iTween.ScaleTo(instance, new Vector3(0, 1, 1), second);
        iTween.MoveTo(instance, from - Vector3.right * length / 2.0f, second);
    }
    protected void SinkY(GameObject instance, float second)
    {
        iTween.ScaleTo(instance, new Vector3(1, 0, 1), second);
        iTween.MoveTo(instance, from - Vector3.up * length / 2.0f, second);
    }
    protected void SinkZ(GameObject instance, float second)
    {
        iTween.ScaleTo(instance, new Vector3(1, 1, 0), second);
        iTween.MoveTo(instance, from - Vector3.forward * length / 2.0f, second);
    }
}