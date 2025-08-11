using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System;
using Unity.VisualScripting;
using UnityEngine.Rendering;

public class PersonProfile : MonoBehaviour
{

    public ScriptableObject profileData;
    public List<DatingPeopleData> profiles = new List<DatingPeopleData>();
    public int ProfilesLeft;
        
    [SerializeField] TMP_Text NameAge;
    [SerializeField] Image ProfilePicture;
    [SerializeField] TMP_Text Distance;
    [SerializeField] TMP_Text Bio;

    [SerializeField] GameObject NameAgeObject;
    [SerializeField] GameObject ProfilePictureObject;
    [SerializeField] GameObject DistanceObject;
    [SerializeField] GameObject BioObject;

     // Match Fill-In
    public GameObject MatchPopUp;
    public GameObject MatchProfileIcon;
    public GameObject MatchText;
    public Image MatchProfilePicture;
    public TMP_Text MatchNameText;
    
    DatingPeopleData currentProfile;
    
    public TMP_Text EdenText;
    public GameObject Profile;
    public GameObject Buttons;
    public GameObject AllDone;

  
    void Awake()
    {
        MatchProfilePicture = MatchProfileIcon.GetComponent<Image>();
        MatchNameText = MatchText.GetComponent<TMP_Text>();

        NameAge = NameAgeObject.GetComponent<TMP_Text>();
        ProfilePicture = ProfilePictureObject.GetComponent<Image>();
        Distance = DistanceObject.GetComponent<TMP_Text>();
        Bio = BioObject.GetComponent<TMP_Text>();
        if (currentProfile == null) 
        {
            GetNextProfile();
        }
    }

    void Update()
    {
        
    }

    public void DisplayProfile()
    {
        NameAge.text = $"<b>{currentProfile.Name}</b>" + " " + $"{currentProfile.Age}";
        ProfilePicture.sprite = currentProfile.ProfilePicture;
        Distance.text = $"{currentProfile.Distance}" + " " + "mi";
        Bio.text = $"{currentProfile.Bio}";

        if (currentProfile.name == "Rachel")
        {
            EdenText.text =
                "The one woman I'll likely see on this app today and it's just a couple looking for a third... again...";
        }
        if (currentProfile.name == "Kyle")
        {
            EdenText.text =
                "That's a silly caption!";
        }
        if (currentProfile.name == "Jeremy")
        {
            EdenText.text =
                "He seems nice!";
        }
        if (currentProfile.name == "Aidan")
        {
            EdenText.text =
                "Hm...";
        }
    }

    public void GetNextProfile()
    {
        if (profiles.Count > 0)
        {
            int index = UnityEngine.Random.Range(0, profiles.Count);
            currentProfile = profiles[index];
            if (profiles.Contains(currentProfile))
            {
                profiles.Remove(currentProfile);
            }
        }
        else if (profiles.Count == 0)
        {
            Profile.SetActive(false);
            Buttons.SetActive(false);
            AllDone.SetActive(true);
            EdenText.text = "Alright, time to check out my messages!";
            return;
        }
        ProfilesLeft--;
        DisplayProfile();
    }

    public bool CheckMatch()
    {
        if (currentProfile.Match == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

        public void ShowMatch() 
    {
        MatchProfilePicture.sprite = currentProfile.ProfilePicture;
        MatchNameText.text = $"You matched with {currentProfile.Name}";
        MatchPopUp.SetActive(true);
        EdenText.text = "oh yay!";
    }
}
