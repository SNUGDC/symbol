using System.Collections;
using UnityEngine;

public partial class InterectWithSymbol : MonoBehaviour
{
    private bool isPressReady;
}
[RequireComponent(typeof(NoticeSymbolSender))]
public partial class InterectWithSymbol : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Left Mouse Click
        if (Input.GetMouseButton(0))
        {
            if (!GetComponent<NoticeSymbolSender>().isReadySymbolEmpty)
            {
                GetComponent<NoticeSymbolSender>().press();
            }
        }
        //Right Mouse Click
        else if (Input.GetMouseButton(1))
        {
        }
        //Middle Mouse Click
        else if (Input.GetMouseButton(2))
        {
        }
    }
}