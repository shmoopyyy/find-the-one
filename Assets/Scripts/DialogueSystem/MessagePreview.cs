using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MessagePreview : MonoBehaviour
{
    public DatingPeopleData Profile;
    
    public Image PFP;
    public TextMeshProUGUI ProfileName;
    public TextMeshProUGUI MessageText;
    public GameObject NotifDoot;
    
    public Button Button;

    public ChatRenderer ChatRenderer;

    public List<GameObject> MessageScreenObjects;
    

    void Awake()
    {
        Button.onClick.AddListener(OnOpenChat);
        NotifDoot.SetActive(true);
        PFP.sprite = Profile.ProfilePicture;
        ProfileName.text = Profile.Name;
        MessageText.text = Profile.ChatData.OpeningMessage;
    }
    
    void OnEnable()
    {
        ChatRenderer.gameObject.SetActive(false);
        foreach (GameObject obj in MessageScreenObjects)
            obj.SetActive(true);
    }

    public void OnOpenChat()
    {
        ChatRenderer.DatingPeopleData = Profile;
        
        ChatRenderer.ResetChat();
        ChatRenderer.gameObject.SetActive(true);

        foreach (GameObject obj in MessageScreenObjects)
            obj.SetActive(false);

        Button.interactable = false;
        MessageText.text = Profile.ChatData.Messages[^1].Message;
        NotifDoot.SetActive(false);
    }
    
}
