using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public struct ChatMessage
{
    public bool Eden;
    public string Message;
}

[CreateAssetMenu(fileName = "NewChatData", menuName = "ScriptableObjects/ChatData")]
public class ChatData : ScriptableObject
{
    public TextAsset ChatFile;

    public string OpeningMessage;
    
    public List<ChatMessage> Messages = new List<ChatMessage>();
    
    public void ParseChatFile()
    {
        Messages = new();
        List<string> RawMessages = ChatFile.text.Split("\n").ToList();

        for (int i = 0; i < RawMessages.Count; i++)
        {
            string rawMessage = RawMessages[i];
            
            int split = rawMessage.IndexOf(':');


            if (i == 0)
            {
                OpeningMessage = rawMessage.Substring(split + 1).Trim();
            }
            else
            {
                Messages.Add(new ChatMessage()
                {
                    Eden = rawMessage.Substring(0, split).Trim().ToLower() == "eden",
                    Message = rawMessage.Substring(split + 1).Trim()
                });
            }
        }
        
        #if UNITY_EDITOR
            EditorUtility.SetDirty(this);
        #endif
    }

}


#if UNITY_EDITOR

[CustomEditor(typeof(ChatData)), CanEditMultipleObjects]
public class ChatDataEditor : Editor
{
    private ChatData script;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        script = target as ChatData;

        if (GUILayout.Button("Parse Chat File"))
            script.ParseChatFile();       
    }
}

#endif
