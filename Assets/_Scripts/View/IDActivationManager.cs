using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDActivationManager : Singleton<IDActivationManager>
{
    [SerializeField] private Transform _roomsParent;

    public void SetObjectActive(string id, bool isActive)
    {
        foreach (var act in _roomsParent.GetComponentsInChildren<IDActivator>(true))
        {
            if (act.ids.Contains(id))
            {
                act.gameObject.SetActive(isActive);
            }
        }
    }
}
