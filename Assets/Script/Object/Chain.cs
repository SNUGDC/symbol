using System.Collections;
using UnityEngine;

public partial class Chain : PerceptibleObject
{
    private void PressSuccess()
    {
        Debug.Log("asdf");
        Player player = (Player)FindObjectOfType(typeof(Player));
        player.transform.parent = transform;
        player.transform.localPosition = Vector3.zero;
        if (player.GetComponent<CharacterController>().enabled)
            player.GetComponent<CharacterController>().enabled = false;
        if (player.GetComponent<CatchChain>() == null)
            player.gameObject.AddComponent<CatchChain>();
    }
    private void PressFailed()
    {
    }
    private void PressReady()
    {
    }
}
public partial class Chain : PerceptibleObject
{
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    public override System.Type getReceiverType()
    {
        return typeof(ChainReceiver);
    }
    public override bool isTouchable()
    {
        return true;
    }
}