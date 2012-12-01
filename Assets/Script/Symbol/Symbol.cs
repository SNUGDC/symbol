using System.Collections;
using UnityEngine;

public class Symbol : PerceptibleObject
{
    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public override bool isTouchable()
    {
        return GetComponent<SymbolState>().state == eSymbolState.NORMAL;
    }

    public override System.Type getReceiverType()
    {
        return typeof(NoticeSymbolReceiver);
    }
}