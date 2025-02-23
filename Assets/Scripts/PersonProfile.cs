using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class PersonProfile : MonoBehaviour
{

    public ScriptableObject profileData;
    public List<DatingPeopleData> profiles = new List<DatingPeopleData>();

    [SerializeField] TMP_Text NameAge;
    [SerializeField] Image ProfilePicture;
    [SerializeField] TMP_Text Distance;
    [SerializeField] TMP_Text Bio;
    
    DatingPeopleData currentProfile;

    void Awake()
    {
        NameAge = GetComponent<TMP_Text>();
        ProfilePicture = GetComponent<Image>();
        Distance = GetComponent<TMP_Text>();
        Bio = GetComponent<TMP_Text>();
    }

    
    void Update()
    {
        
    }

    void DisplayProfile(DatingPeopleData currentProfile)
    {
        NameAge.text = $"<b>{currentProfile.Name}</b>" + " " + $"{currentProfile.Age}";
    }

    public void GetNextProfile()
    {
        if (profiles.Count > 0)
        {
            int index = Random.Range(0, profiles.Count);
            currentProfile = profiles[index];
            if (profiles.Contains(currentProfile))
            {
                profiles.Remove(currentProfile);
            }
        }
    }
}
