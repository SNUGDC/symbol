using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SymbolState))]
public class NoticePlayer : MonoBehaviour
{
    public float distance = 2.0f;
    private bool isPressReady;

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
            //�÷��̾ �ٰ�����, ���� �غ���°� �ƴ� ��
            //���� �غ���·� �����.
            if (isColliderPlayer(hit) && !isPressReady)
            {
                isPressReady = true;
                gameObject.SendMessage("PressReady");
                //Player���� Dispatch
                //hit.collider.gameObject.SendMessage("PressReady");
            }
        }
        //�÷��̾ ������ �ְ�, ���� �غ������ ��
        //���� �غ���¸� �����Ѵ�.
        else if (isPressReady)
        {
            isPressReady = false;
            gameObject.SendMessage("PressFailed");
        }
    }

    private bool isColliderPlayer(RaycastHit hit)
    {
        Player player = hit.collider.gameObject.GetComponent<Player>();
        return player != null;
    }
}