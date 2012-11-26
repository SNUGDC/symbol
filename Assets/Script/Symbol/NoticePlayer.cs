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
            //플레이어가 다가오고, 누름 준비상태가 아닐 때
            //누름 준비상태로 만든다.
            if (isColliderPlayer(hit) && !isPressReady)
            {
                isPressReady = true;
                gameObject.SendMessage("PressReady");
                HelpText.instance.SendMessage("PressReady");
                //Player에게 Dispatch
                //hit.collider.gameObject.SendMessage("PressReady");
            }
        }
        //플레이어가 떨어져 있고, 누름 준비상태일 때
        //누름 준비상태를 해제한다.
        else if (isPressReady)
        {
            isPressReady = false;
            gameObject.SendMessage("PressFailed");
            HelpText.instance.SendMessage("PressFailed");
        }
    }

    private bool isColliderPlayer(RaycastHit hit)
    {
        Player player = hit.collider.gameObject.GetComponent<Player>();
        return player != null;
    }
}