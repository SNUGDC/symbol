using System.Collections;
using UnityEngine;

public partial class NoticeSymbolSender : MonoBehaviour
{
    public float distance = 2.0f;
    private bool _isPressReady;

    public bool isPressReady
    {
        get { return _isPressReady; }
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
        _isPressReady = false;
        SendReceiveUtil.SendMessageToReceivers<NoticeSymbolReceiver>("PressSuccess");
    }
}

public partial class NoticeSymbolSender : MonoBehaviour
{
    private void Start()
    {
        _isPressReady = false;
    }

    // Update is called once per frame
    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distance))
        {
            //�÷��̾ �ٰ�����, ���� �غ���°� �ƴ� ��
            //���� �غ���·� �����.
            if (isColliderNormalSymbol(hit) && !_isPressReady)
            {
                _isPressReady = true;
                SendReceiveUtil.SendMessageToReceivers<NoticeSymbolReceiver>("PressReady");
            }
        }
        //�÷��̾ ������ �ְ�, ���� �غ������ ��
        //���� �غ���¸� �����Ѵ�.
        else if (_isPressReady)
        {
            _isPressReady = false;
            SendReceiveUtil.SendMessageToReceivers<NoticeSymbolReceiver>("PressFailed");
        }
    }
}

public partial class NoticeSymbolSender : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        RaycastHit hit;
        Color color = Color.red;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distance))
        {
            if (isColliderNormalSymbol(hit))
            {
                color = Color.green;
            }
        }
        Gizmos.color = color;
        Gizmos.DrawLine(transform.position, transform.position + transform.TransformDirection(Vector3.forward) * distance);
    }
}