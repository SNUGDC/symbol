using System.Collections;
using UnityEngine;

public enum eSymbolState
{
    DISABLE,
    ACTIVE,
    HOVER,
    NORMAL,
}

[RequireComponent(typeof(NoticeSymbolReceiver))]
public partial class SymbolState : MonoBehaviour
{
    public eSymbolState state = eSymbolState.NORMAL;
    //state의 변화를 감지한다.
    private eSymbolState prev_state;
}

public partial class SymbolState : MonoBehaviour
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
    //State Pattern을 적용해볼까
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
    }
    private void PressSuccess()
    {
        switch (state)
        {
            case eSymbolState.HOVER:
                state = eSymbolState.ACTIVE;
                break;
            case eSymbolState.NORMAL:
            case eSymbolState.DISABLE:
            case eSymbolState.ACTIVE:
                break;
        }
    }
}
public partial class SymbolState : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (prev_state != state)
        {
            _changeColor();
            prev_state = state;
        }
    }
}