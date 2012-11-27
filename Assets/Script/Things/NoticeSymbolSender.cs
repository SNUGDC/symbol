using System.Collections;
using UnityEngine;

public partial class NoticeSymbolSender : MonoBehaviour
{
    public float distance = 2.0f;
    private GameObject _readySymbol;

    public bool isReadySymbolEmpty
    {
        get { return _readySymbol == null; }
    }
}

public partial class NoticeSymbolSender : MonoBehaviour
{
    private bool isColliderNormalSymbol(RaycastHit hit)
    {
        Symbol symbol = hit.collider.gameObject.GetComponent<Symbol>();
        if (symbol != null)
            return symbol.GetComponent<SymbolState>().state == eSymbolState.NORMAL;
        return false;
    }

    public void press()
    {
        _readySymbol = null;
        SendReceiveUtil.SendMessageToReceivers<NoticeSymbolReceiver>("PressSuccess");
    }
}

public partial class NoticeSymbolSender : MonoBehaviour
{
    private void Start()
    {
        _readySymbol = null;
    }

    // Update is called once per frame
    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distance))
        {
            //플레이어가 다가오고, 누름 준비상태가 아닐 때
            //누름 준비상태로 만든다.
            if (isReadySymbolEmpty)
            {
                if (isColliderNormalSymbol(hit))
                {
                    _readySymbol = hit.collider.gameObject;
                    hit.collider.gameObject.AddComponent<NoticeSymbolReceiver>();
                    SendReceiveUtil.SendMessageToReceivers<NoticeSymbolReceiver>("PressReady");
                }
            }
            //누름 준비상태이면서 Raycast 객체가 변화하였을때 누름 준비상태를 해제한다.
            else if (hit.collider.gameObject != _readySymbol)
            {
                _readySymbol = null;
                SendReceiveUtil.SendMessageToReceivers<NoticeSymbolReceiver>("PressFailed");
            }
        }
        //플레이어가 떨어져 있고, 누름 준비상태일 때
        //누름 준비상태를 해제한다.
        else if (!isReadySymbolEmpty)
        {
            _readySymbol = null;
            SendReceiveUtil.SendMessageToReceivers<NoticeSymbolReceiver>("PressFailed");
        }
    }
}

public partial class NoticeSymbolSender : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.TransformDirection(Vector3.forward) * distance);
    }
}