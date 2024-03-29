using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendReceiveUtil
{
    public static void SendMessageToReceivers<T>(string eventName, object eventData = null) where T : MonoBehaviour
    {
        T[] receivers = (T[])GameObject.FindObjectsOfType(typeof(T));
        foreach (T receiver in receivers)
        {
            receiver.gameObject.SendMessage(eventName, eventData);
        }
    }
    public static void SendMessageToReceivers(System.Type type, string eventName, object eventData = null)
    {
        Debug.Log(eventName);
        Object[] receivers = GameObject.FindObjectsOfType(type);

        foreach (NoticeReceiver receiver in receivers)
        {
            receiver.gameObject.SendMessage(eventName, eventData);
        }
    }
}