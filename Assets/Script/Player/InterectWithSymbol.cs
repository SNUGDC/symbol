using System.Collections;
using UnityEngine;

public partial class InterectWithSymbol : MonoBehaviour
{
    private bool isPressReady;
}
[RequireComponent(typeof(NoticeSymbolReceiver))]
public partial class InterectWithSymbol : MonoBehaviour
{
    public void PressReady()
    {
        isPressReady = true;
    }
    public void PressFailed()
    {
    }
    public void PressSuccess()
    {
    }
}

public partial class InterectWithSymbol : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}