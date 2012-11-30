using System.Collections;
using UnityEngine;

public class DoorAction : MonoBehaviour
{
    public float angle = 90.0f;
    public float second = 2.5f;
    public bool isOpenDoor;
    public bool isCloseDoor;
    // Use this for initialization
    void Start()
    {
        isOpenDoor = false;
        isCloseDoor = false;
        StartCoroutine(OpenDoor());
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpenDoor)
            transform.RotateAround(transform.position + Vector3.right * 0.5f, Vector3.up, -angle * Time.deltaTime / second);
        if (isCloseDoor)
            transform.RotateAround(transform.position + Vector3.right * 0.5f, Vector3.up, angle * Time.deltaTime / second);
    }
    public IEnumerator OpenDoor()
    {
        isOpenDoor = true;
        yield return new WaitForSeconds(second);
        isOpenDoor = false;
        StartCoroutine(CloseDoor());
    }
    public IEnumerator CloseDoor()
    {
        isCloseDoor = true;
        yield return new WaitForSeconds(second);
        isCloseDoor = false;
        StartCoroutine(OpenDoor());
    }
}