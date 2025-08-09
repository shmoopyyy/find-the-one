using System;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Profile", menuName = "ScriptableObjects/Profiles")]
public class DatingPeopleData : ScriptableObject
{
    public string Name;
    public int Age;
    [TextArea(2,6)]
    public string Bio;
    public float Distance;
    public Sprite ProfilePicture;
    public bool Match;
    public ChatData ChatData;

    public string GetName()
    {
        return Name;
    }

    public int GetAge()
    {
        return Age;
    }

    public string GetBio()
    {
        return Bio;
    }

    public float GetDistance()
    {
        return Distance;
    }

    public Sprite GetProfilePicture()
    {
        return ProfilePicture;
    }

    public bool GetMatchBool() 
    {
        return Match;
    }

    public ChatData GetChatData()
    {
        return ChatData;
    }
}
