using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DatingAppManager : MonoBehaviour
{

    // General App
    public GameObject ProfileScreen;
    public GameObject MessagesScreen;
    public GameObject LikesScreen;
    public GameObject PeopleScreen;

    public Button ProfileButton;
    public Button MessagesButton;
    public Button LikesButton;
    public Button PeopleButton;

    //Profile Screen
    public Button LikeButton;
    public Button SkipButton;
   
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnEnable()
    {
        ProfileButton.onClick.AddListener(() => ScreenButtonClicked(ProfileButton));
        MessagesButton.onClick.AddListener(() => ScreenButtonClicked(MessagesButton));
        LikesButton.onClick.AddListener(() => ScreenButtonClicked(LikesButton));
        PeopleButton.onClick.AddListener(() => ScreenButtonClicked(PeopleButton));
        LikeButton.onClick.AddListener(() => NextProfile());
        SkipButton.onClick.AddListener(() => NextProfile());
    }

    void ScreenButtonClicked(Button buttonClicked)
    {
        if (buttonClicked == ProfileButton)
        {
            ProfileScreen.SetActive(true);
            MessagesScreen.SetActive(false);
            LikesScreen.SetActive(false);
            PeopleScreen.SetActive(false);
        } else if (buttonClicked == MessagesButton)
        {
            ProfileScreen.SetActive(false);
            MessagesScreen.SetActive(true);
            LikesScreen.SetActive(false);
            PeopleScreen.SetActive(false);
        } else if (buttonClicked == LikesButton)
        {
            ProfileScreen.SetActive(false);
            MessagesScreen.SetActive(false);
            LikesScreen.SetActive(true);
            PeopleScreen.SetActive(false);
        } else if (buttonClicked == PeopleButton)
        {
            ProfileScreen.SetActive(false);
            MessagesScreen.SetActive(false);
            LikesScreen.SetActive(false);
            PeopleScreen.SetActive(true);
        }
    }

    private void NextProfile()
    {

    }
}

