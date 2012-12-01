using System.Collections;
using UnityEngine;

public partial class NoticeObjectSender : MonoBehaviour
{
    public float distance = 2.0f;
    private GameObject _readyObject;
    private System.Type _receiver_type;
}

public partial class NoticeObjectSender : MonoBehaviour
{
    private bool isReadyObjectEmpty()
    {
        return _readyObject == null;
    }

    private void noticeReset()
    {
        _readyObject = null;
        _receiver_type = null;
    }

    #region CHECK NOTICE

    public void CheckNoticeObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distance))
        {
            PerceptibleObject obj = hit.collider.gameObject.GetComponent<PerceptibleObject>();
            if (obj == null)
                return;
            //플레이어가 다가오고, 누름 준비상태가 아닐 때
            //누름 준비상태로 만든다.
            if (isReadyObjectEmpty())
            {
                if (obj.isTouchable())
                {
                    _readyObject = hit.collider.gameObject;
                    _receiver_type = obj.getReceiverType();
                    obj.gameObject.AddComponent(_receiver_type);
                    SendReceiveUtil.SendMessageToReceivers(_receiver_type, "PressReady");
                }
            }
            //누름 준비상태이면서 Raycast 객체가 변화하였을때 누름 준비상태를 해제한다.
            else if (hit.collider.gameObject != _readyObject)
            {
                SendReceiveUtil.SendMessageToReceivers(_receiver_type, "PressFailed");
                noticeReset();
            }
        }
        //플레이어가 떨어져 있고, 누름 준비상태일 때
        //누름 준비상태를 해제한다.
        else if (!isReadyObjectEmpty())
        {
            SendReceiveUtil.SendMessageToReceivers(_receiver_type, "PressFailed");
            noticeReset();
        }
    }

    public void CheckSelectObject()
    {
        //Left Mouse Click
        if (Input.GetMouseButton(0))
        {
            if (!isReadyObjectEmpty())
            {
                SendReceiveUtil.SendMessageToReceivers(_receiver_type, "PressSuccess");
                noticeReset();
            }
        }
    }

    #endregion CHECK NOTICE
}

public partial class NoticeObjectSender : MonoBehaviour
{
    private void Start()
    {
        noticeReset();
    }

    // Update is called once per frame
    private void Update()
    {
        CheckNoticeObject();
        CheckSelectObject();
    }
}

public partial class NoticeObjectSender : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.TransformDirection(Vector3.forward) * distance);
    }
}