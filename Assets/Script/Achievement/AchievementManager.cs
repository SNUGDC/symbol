using UnityEngine;
using System.Collections;

public partial class AchievementManager : MonoBehaviour
{
    private static AchievementManager _instance;

    public static AchievementManager instance
    {
        get {
            if (_instance == null)
                _instance = (AchievementManager)FindObjectOfType(typeof(AchievementManager));
            return _instance;
        }
    }
}

public struct sAchievement
{
    string name;
    string discription;
    Texture2D image;
}

public partial class AchievementManager : MonoBehaviour
{
    public sAchievement[] achivements;
}

public partial class AchievementManager : MonoBehaviour
{
    public void addAchievement(Achievement achievement)
    {
        achievement.GetInstanceID();
    }
}

public partial class AchievementManager : MonoBehaviour
{
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
