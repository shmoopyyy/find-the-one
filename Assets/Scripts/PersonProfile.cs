using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PersonProfile : MonoBehaviour
{

    public ScriptableObject profileData;
    public List<DatingPeopleData> profiles = new List<DatingPeopleData>();
    DatingPeopleData currentProfile;

    void Awake()
    {
        
    }

    
    void Update()
    {
        
    }

    void DisplayProfile()
    {

    }

    void GetNextProfile()
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
