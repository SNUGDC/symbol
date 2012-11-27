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
            //플레이어가 다가오고, 누름 준비상태가 아닐 때
            //누름 준비상태로 만든다.
            if (isColliderSymbol(hit) && !isPressReady)
            {
                isPressReady = true;
                SendReceiveUtil.SendMessageToReceivers<NoticeSymbolReceiver>("PressReady");
            }
        }
        //플레이어가 떨어져 있고, 누름 준비상태일 때
        //누름 준비상태를 해제한다.
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