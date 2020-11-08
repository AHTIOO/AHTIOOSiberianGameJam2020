using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDActivationManager : Singleton<IDActivationManager>
{
    public void SetObjectActive(string id, bool isActive)
    {
        foreach (var act in FindObjectsOfType<IDActivator>())
        {
            if (act.ids.Contains(id))
            {
                act.gameObject.SetActive(isActive);
            }
        }
    }
}
