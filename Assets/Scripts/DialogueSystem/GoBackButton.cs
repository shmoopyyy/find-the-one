using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoBackButton : MonoBehaviour
{
    public List<GameObject> DisableObjects;
    public List<GameObject> EnableObjects;
    public TMP_Text EdenText;
    public GameObject JeremyEnding;
    private int MessagesRead = 0;
    
    public void GoBack()
    {
        foreach (GameObject obj in DisableObjects)
            obj.SetActive(false);
        
        foreach (GameObject obj in EnableObjects)
            obj.SetActive(true);

        EdenText.text = "";
        MessagesRead++;

        if (MessagesRead == 3)
        {
            EdenText.text = "Alright well, at least I can look forward to my date with Jeremy!";
            JeremyEnding.SetActive(true);
        }
    }
}
