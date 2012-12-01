using System.Collections;
using UnityEngine;

public enum eSymbolState
{
    DISABLE,
    ACTIVE,
    HOVER,
    NORMAL,
}

[RequireComponent(typeof(Symbol))]
public partial class Symbol : PerceptibleObject
{
    public eSymbolState state = eSymbolState.NORMAL;
    public float normailzeTime = 2.0f;

    //state�� ��ȭ�� �����Ѵ�.
    private eSymbolState prev_state;
}

public partial class Symbol : PerceptibleObject
{
    private void _changeColor()
    {
        switch (state)
        {
            case eSymbolState.DISABLE:
                GetComponent<tk2dSprite>().color = Color.gray;
                break;
            case eSymbolState.NORMAL:
                GetComponent<tk2dSprite>().color = Color.white;
                break;
            case eSymbolState.HOVER:
                GetComponent<tk2dSprite>().color = Color.yellow;
                break;
            case eSymbolState.ACTIVE:
                GetComponent<tk2dSprite>().color = Color.green;
                break;
        }
    }

    //State Pattern�� �����غ���
    private void PressReady()
    {
        switch (state)
        {
            case eSymbolState.NORMAL:
                state = eSymbolState.HOVER;
                break;
            case eSymbolState.HOVER:
            case eSymbolState.DISABLE:
            case eSymbolState.ACTIVE:
                break;
        }
    }

    private void PressFailed()
    {
        switch (state)
        {
            case eSymbolState.HOVER:
                state = eSymbolState.NORMAL;
                break;
            case eSymbolState.NORMAL:
            case eSymbolState.DISABLE:
            case eSymbolState.ACTIVE:
                break;
        }
        //�̳��� �̰��� �ִ°� ������?
        Destroy(GetComponent<SymbolReceiver>());
    }

    private IEnumerator normalizeState(float time)
    {
        yield return new WaitForSeconds(time);
        state = eSymbolState.NORMAL;
    }

    private void PressSuccess()
    {
        switch (state)
        {
            case eSymbolState.HOVER:
                state = eSymbolState.ACTIVE;
                StartCoroutine(normalizeState(normailzeTime));
                break;
            case eSymbolState.NORMAL:
            case eSymbolState.DISABLE:
            case eSymbolState.ACTIVE:
                break;
        }
        //�̳��� �̰��� �ִ°� ������?
        Destroy(GetComponent<SymbolReceiver>());
    }
}

public partial class Symbol : PerceptibleObject
{
    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (prev_state != state)
        {
            _changeColor();
            prev_state = state;
        }
    }

    public override bool isTouchable()
    {
        return state == eSymbolState.NORMAL;
    }

    public override System.Type getReceiverType()
    {
        return typeof(SymbolReceiver);
    }
}