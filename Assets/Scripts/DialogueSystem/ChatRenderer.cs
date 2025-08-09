using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChatRenderer : MonoBehaviour
{
    public float WaitTimePerCharacter = 0.01f;
    
    public DatingPeopleData DatingPeopleData;

    [Header("Header")] 
    public Image PFP;
    public TextMeshProUGUI ProfileName;
    public Button GoBackButton;
    
    [Header("Chat Bubble Elements")]
    public ScrollRect ScrollRect;
    public GameObject ChatBubblePrefab;
    public GameObject ElipsisBubble;
    public GameObject EdenElipsis;

    [Header("Typing Area Elements")]
    public TextMeshProUGUI TypingText;
    public GameObject TypingPlaceholderText;
    public Image SendButtonBG;
    public Button SendButton;
    
    private bool _click;
    private List<GameObject> _chatBubbles = new();
    
    private void OnEnable()
    {
        PFP.sprite = DatingPeopleData.ProfilePicture;
        ProfileName.text = DatingPeopleData.Name;
        GoBackButton.interactable = false;
        
        ScrollRect.verticalNormalizedPosition = 0; 
        SendButtonBG.enabled = false;
        SendButton.interactable = false;
        ElipsisBubble.SetActive(false);
        EdenElipsis.SetActive(false);
        TypingPlaceholderText.SetActive(true);
        TypingText.text = "";
        
        RenderChat();
    }

    public void RenderChat(DatingPeopleData peopleData)
    {
        DatingPeopleData = peopleData;
        RenderChat();
    }
    
    [ContextMenu("Render Chat")]
    public void RenderChat()
    {
        StartCoroutine(RenderChatRoutine());
    }

    public IEnumerator RenderChatRoutine()
    {
        GameObject openingMessage = Instantiate(ChatBubblePrefab, ScrollRect.content);
        ChatBubble cbOpener = openingMessage.GetComponent<ChatBubble>();
        cbOpener.InitChatBubble(new ChatMessage(){ Eden = false, Message = DatingPeopleData.ChatData.OpeningMessage });
        openingMessage.transform.SetAsLastSibling();
        _chatBubbles.Add(openingMessage);
        
        yield return new WaitForSeconds(1);
        
        foreach (ChatMessage message in DatingPeopleData.ChatData.Messages)
        {
            if (message.Eden)
            {
                EdenElipsis.transform.SetAsLastSibling();
                EdenElipsis.SetActive(true);
                ElipsisBubble.SetActive(false);
                SendButtonBG.enabled = false;
                SendButton.interactable = false;
                Coroutine typingRoutine = StartCoroutine(TypeEdenMessage(message.Message));
                
                yield return null;
                ScrollRect.verticalNormalizedPosition = 0; 
                yield return new WaitUntil(() => _click);
                
                EdenElipsis.gameObject.SetActive(false);
                SendButtonBG.enabled = false;
                SendButton.interactable = false;
                
                StopCoroutine(typingRoutine);
                TypingPlaceholderText.SetActive(true);
                TypingText.text = "";
                
                _click = false;
            }
            else
            {
                ElipsisBubble.transform.SetAsLastSibling();
                ElipsisBubble.SetActive(true);
                EdenElipsis.SetActive(false);

                yield return null;
                ScrollRect.verticalNormalizedPosition = 0; 
                yield return new WaitForSeconds(WaitTimePerCharacter * message.Message.Length);

                ElipsisBubble.SetActive(false);
            }
            
            GameObject obj = Instantiate(ChatBubblePrefab, ScrollRect.content);
            ChatBubble chatBubble = obj.GetComponent<ChatBubble>();
            chatBubble.InitChatBubble(message);
            obj.transform.SetAsLastSibling();
            _chatBubbles.Add(obj);

            
            yield return null;
            yield return null;
            
            ScrollRect.verticalNormalizedPosition = 0;
            
            yield return new WaitForSeconds(1);
        }
        
        GoBackButton.interactable = true;
    }

    public void OnClick()
    {
        _click = true;
    }

    public IEnumerator TypeEdenMessage(string message)
    {
        TypingText.text = "";
        TypingPlaceholderText.SetActive(false);
        
        WaitForSeconds wait = new WaitForSeconds(WaitTimePerCharacter);
        
        foreach (char c in message)
        {
            TypingText.text += c;
            yield return wait;
            ScrollRect.verticalNormalizedPosition = 0; 
        }

        SendButtonBG.enabled = true;
        SendButton.interactable = true;
    }

    public void ResetChat()
    {
        if (_chatBubbles.Count == 0)
            return;
        
        for (int i = 0; i < _chatBubbles.Count; i++)
            Destroy(_chatBubbles[i]);
        _chatBubbles.Clear();
        
        StopAllCoroutines();
    }

}
