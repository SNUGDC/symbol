using System.Collections;
using UnityEngine;

public class CatchChain : MonoBehaviour
{
    private bool isDetachAvailable = false;
    private float detach_available_time = 0.5f;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(ReadyDetach());
    }

    private IEnumerator ReadyDetach()
    {
        yield return new WaitForSeconds(detach_available_time);
        isDetachAvailable = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && isDetachAvailable)
        {
            isDetachAvailable = false;
            gameObject.GetComponent<CharacterController>().enabled = true;
            transform.parent.DetachChildren();
            Destroy(this);
        }
    }
}