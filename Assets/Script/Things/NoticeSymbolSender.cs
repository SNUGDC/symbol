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
            //�÷��̾ �ٰ�����, ���� �غ���°� �ƴ� ��
            //���� �غ���·� �����.
            if (isReadySymbolEmpty)
            {
                if (isColliderNormalSymbol(hit))
                {
                    _readySymbol = hit.collider.gameObject;
                    hit.collider.gameObject.AddComponent<NoticeSymbolReceiver>();
                    SendReceiveUtil.SendMessageToReceivers<NoticeSymbolReceiver>("PressReady");
                }
            }
            //���� �غ�����̸鼭 Raycast ��ü�� ��ȭ�Ͽ����� ���� �غ���¸� �����Ѵ�.
            else if (hit.collider.gameObject != _readySymbol)
            {
                _readySymbol = null;
                SendReceiveUtil.SendMessageToReceivers<NoticeSymbolReceiver>("PressFailed");
            }
        }
        //�÷��̾ ������ �ְ�, ���� �غ������ ��
        //���� �غ���¸� �����Ѵ�.
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