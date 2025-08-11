using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class DatingAppManager : MonoBehaviour
{

    // General App
    public GameObject ProfilePage;
    public GameObject MessagesPage;
    public GameObject LikesPage;
    public GameObject PeoplePage;

    public Button ProfileButton;
    public Button MessagesButton;
    public Button LikesButton;
    public Button PeopleButton;

    List<Button> PageButtons = new List<Button>();
    List<GameObject> Pages = new List<GameObject>();

    public PersonProfile PersonProfile;
    
    public TMP_Text EdenText;
    
    //People Screen
    [Header("People Screen")]
    public GameObject ProfileContainer;
    public PersonProfile profile;
    public Button HeartButton;
    public Button SkipButton;

    //Likes Screen
    public Button UpgradeButton;
    
    //Match Pop Up
    [Header("Match Pop Up")]
    public GameObject MatchPopUp;
    public Button MatchClose;

    void Start()
    {
        profile = ProfileContainer.GetComponent<PersonProfile>();

        PageButtons.Add(ProfileButton); PageButtons.Add(MessagesButton); PageButtons.Add(LikesButton); PageButtons.Add(PeopleButton);
        Pages.Add(ProfilePage); Pages.Add(MessagesPage); Pages.Add(LikesPage); Pages.Add(PeoplePage);

        for (int i = 0; i < Pages.Count; i++)
        {
            if (Pages[i] == LikesPage)
            {
                Pages[i].SetActive(true);
            }
            else
            {
                Pages[i].SetActive(false);
            }
        }

        ProfileButton.onClick.AddListener(() => ChangePage(ProfileButton));
        MessagesButton.onClick.AddListener(() => ChangePage(MessagesButton));
        LikesButton.onClick.AddListener(() => ChangePage(LikesButton));
        PeopleButton.onClick.AddListener(() => ChangePage(PeopleButton));
        HeartButton.onClick.AddListener(() => NextProfile(HeartButton));
        SkipButton.onClick.AddListener(() => NextProfile(SkipButton));
        MatchClose.onClick.AddListener(() => ClosePopUp());
        UpgradeButton.onClick.AddListener(() => EdenText.text = "I'd rather not spend money on this app...");
        
        EdenText.text = "Alright, time to see if I meet any new people today! I'm pretty sure that page uses the flame icon, right?";
    }

    void Update()
    {

    }

    void ChangePage(Button buttonClicked)
    {
        for (int i = 0; i < PageButtons.Count; i++) {
            if (buttonClicked == PageButtons[i]) 
            {
                if (buttonClicked == MessagesButton && PersonProfile.ProfilesLeft > 0)
                {
                    EdenText.text =
                        "I don't want to read messages until I swipe on all the profiles for today...";
                    return;
                }

                if (buttonClicked == ProfileButton)
                {
                    EdenText.text =
                        "I don't think I need to update my profile right now.";
                    return;
                }
                Pages[i].SetActive(true);
                LoadPage(Pages[i]);
            } else {
                Pages[i].SetActive(false);
            }
        }
    }

    void LoadPage(GameObject page) 
    {
        /*
        if (page == ProfilePage)
        {

        }
        if (page == MessagesPage)
        {

        }
        if (page == LikesPage) 
        {

        }
        */
        if (page == PeoplePage) 
        {
            profile.DisplayProfile();
        }
    }

    // Profile Page 
    private void NextProfile(Button buttonClicked)
    {
        if (buttonClicked == HeartButton) 
        {
            profile.CheckMatch();
            if (profile.CheckMatch() == true)
            {
                profile.ShowMatch();
            }
            else
            {
                profile.GetNextProfile();
            }
        } else if (buttonClicked == SkipButton)
        {
            profile.GetNextProfile();
        }
    }

    //Messages Screen
    
    
    //Match Pop Up
    private void ClosePopUp() 
    {
        MatchPopUp.SetActive(false);
        profile.GetNextProfile();
    }
}

