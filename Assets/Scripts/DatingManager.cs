using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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
   
    void Start()
    {
        profile = ProfileContainer.GetComponent<PersonProfile>();

        PageButtons.Add(ProfileButton); PageButtons.Add(MessagesButton); PageButtons.Add(LikesButton); PageButtons.Add(PeopleButton);
        Pages.Add(ProfilePage); Pages.Add(MessagesPage); Pages.Add(LikesPage); Pages.Add(PeoplePage);

        ProfileButton.onClick.AddListener(() => ChangePage(ProfileButton));
        MessagesButton.onClick.AddListener(() => ChangePage(MessagesButton));
        LikesButton.onClick.AddListener(() => ChangePage(LikesButton));
        PeopleButton.onClick.AddListener(() => ChangePage(PeopleButton));
        HeartButton.onClick.AddListener(() => NextProfile());
        SkipButton.onClick.AddListener(() => NextProfile());
    }

    void Update()
    {

    }

    void ChangePage(Button buttonClicked)
    {
        for (int i = 0; i < PageButtons.Count; i++) {
            if (buttonClicked == PageButtons[i]) 
            {
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
    private void NextProfile()
    {
        if ("HeartButton" == EventSystem.current.currentSelectedGameObject.name) 
        {
            profile.GetNextProfile();
        } else if ("SkipButton" == EventSystem.current.currentSelectedGameObject.name)
        {
            profile.GetNextProfile();
        }
    }
}

