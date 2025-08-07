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

    //People Screen
    [Header("People Screen")]
    public GameObject ProfileContainer;
    public PersonProfile profile;
    public Button HeartButton;
    public Button SkipButton;

    //Match Pop Up
    [Header("Match Pop Up")]
    public GameObject MatchPopUp;
    public Button MatchClose;

    void Start()
    {
        profile = ProfileContainer.GetComponent<PersonProfile>();

        PageButtons.Add(ProfileButton); PageButtons.Add(MessagesButton); PageButtons.Add(LikesButton); PageButtons.Add(PeopleButton);
        Pages.Add(ProfilePage); Pages.Add(MessagesPage); Pages.Add(LikesPage); Pages.Add(PeoplePage);

        ProfileButton.onClick.AddListener(() => ChangePage(ProfileButton));
        MessagesButton.onClick.AddListener(() => ChangePage(MessagesButton));
        LikesButton.onClick.AddListener(() => ChangePage(LikesButton));
        PeopleButton.onClick.AddListener(() => ChangePage(PeopleButton));
        HeartButton.onClick.AddListener(() => NextProfile(HeartButton));
        SkipButton.onClick.AddListener(() => NextProfile(SkipButton));
        MatchClose.onClick.AddListener(() => ClosePopUp());
    }

    void Update()
    {

    }

    void ChangePage(Button buttonClicked)
    {
        for (int i = 0; i < PageButtons.Count; i++) {
            if (buttonClicked == PageButtons[i]) 
            {
                if (buttonClicked == MessagesButton)
                {
                    
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
            profile.GetNextProfile();
        } else if (buttonClicked == SkipButton)
        {
            profile.GetNextProfile();
        }
    }

    //Match Pop Up
    private void ClosePopUp() 
    {
        MatchPopUp.SetActive(false);
    }
}

