using System.Collections.Generic;
using UnityEngine;

public class GoBackButton : MonoBehaviour
{
    public List<GameObject> DisableObjects;
    public List<GameObject> EnableObjects;
    
    public void GoBack()
    {
        foreach (GameObject obj in DisableObjects)
            obj.SetActive(false);
        
        foreach (GameObject obj in EnableObjects)
            obj.SetActive(true);
    }
}
