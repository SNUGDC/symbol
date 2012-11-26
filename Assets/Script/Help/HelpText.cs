using System.Collections;
using UnityEngine;

[RequireComponent(typeof(GUIText))]
public partial class HelpText : MonoBehaviour
{
    private static HelpText _instance;

    public static HelpText instance
    {
        get
        {
            if (_instance == null)
                _instance = (HelpText)FindObjectOfType(typeof(HelpText));
            return _instance;
        }
    }
}

public partial class HelpText : MonoBehaviour
{
    public void PressReady()
    {
        this.guiText.enabled = true;
        this.guiText.text = "Left Mouse Click!";
    }
    public void PressSuccess()
    {
        this.guiText.enabled = false;
    }
    public void PressFailed()
    {
        this.guiText.enabled = false;
    }
}

public partial class HelpText : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}