using System.Collections;
using UnityEngine;

public partial class NoticeSymbolSender : MonoBehaviour
{
    public float distance = 2.0f;
    private bool isPressReady;
}

public partial class NoticeSymbolSender : MonoBehaviour
{
    private bool isColliderSymbol(RaycastHit hit)
    {
        Symbol symbol = hit.collider.gameObject.GetComponent<Symbol>();
        return symbol != null;
    }
}

public partial class NoticeSymbolSender : MonoBehaviour
{
    private void Start()
    {
        isPressReady = false;
    }

    // Update is called once per frame
    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distance))
        {
            Debug.Log("hit : " + hit.collider.gameObject.name);
            //�÷��̾ �ٰ�����, ���� �غ���°� �ƴ� ��
            //���� �غ���·� �����.
            if (isColliderSymbol(hit) && !isPressReady)
            {
                isPressReady = true;
                SendReceiveUtil.SendMessageToReceivers<NoticeSymbolReceiver>("PressReady");
            }
        }
        //�÷��̾ ������ �ְ�, ���� �غ������ ��
        //���� �غ���¸� �����Ѵ�.
        else if (isPressReady)
        {
            isPressReady = false;
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
            if (isColliderSymbol(hit))
            {
                color = Color.green;
            }
        }
        Gizmos.color = color;
        Gizmos.DrawLine(transform.position, transform.position + transform.TransformDirection(Vector3.forward) * distance);
    }
}