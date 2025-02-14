using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "DatingPeopleData", menuName = "Scriptable Objects/DatingPeopleData")]
public class DatingPeopleData : ScriptableObject
{
    public string ProfileName;
    public int Age;
    [TextArea(2,6)]
    public string Bio;
    public float MilesAway;
    public Sprite ProfilePicture;

    public string GetName()
    {
        return ProfileName;
    }

    public int GetAge()
    {
        return Age;
    }

    public string GetBio()
    {
        return Bio;
    }

    public float GetMilesAway()
    {
        return MilesAway;
    }

    public Sprite GetProfilePicture()
    {
        return ProfilePicture;
    }
}
