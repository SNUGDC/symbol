using UnityEngine;
using System.Collections;

public class Achievement : MonoBehaviour
{
    void Start()
    {
        AchievementManager.instance.addAchievement(this);
    }

    protected void achieve()
    {
        Destroy(this);
    }
}
