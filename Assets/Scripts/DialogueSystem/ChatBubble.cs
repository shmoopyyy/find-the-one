using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChatBubble : MonoBehaviour
{
    public VerticalLayoutGroup BubbleGroup;
    public VerticalLayoutGroup SizerGroup;
    
    public TextMeshProUGUI OtherTextSizer;
    public TextMeshProUGUI OtherTextText;
    
    public TextMeshProUGUI EdenTextSizer;
    public TextMeshProUGUI EdenTextText;
    
    
    public void InitChatBubble(ChatMessage message)
    {
        if (message.Eden)
        {
            BubbleGroup.childAlignment = TextAnchor.UpperRight;
            SizerGroup.childAlignment = TextAnchor.UpperRight;
            
            EdenTextSizer.text = message.Message;
            EdenTextText.text = message.Message;
            
            EdenTextSizer.gameObject.SetActive(true);
            OtherTextSizer.gameObject.SetActive(false);
        }
        else
        {
            BubbleGroup.childAlignment = TextAnchor.UpperLeft;
            SizerGroup.childAlignment = TextAnchor.UpperLeft;
            
            OtherTextSizer.text = message.Message;
            OtherTextText.text = message.Message;
            
            OtherTextSizer.gameObject.SetActive(true);
            EdenTextSizer.gameObject.SetActive(false);
        }
    }
}
