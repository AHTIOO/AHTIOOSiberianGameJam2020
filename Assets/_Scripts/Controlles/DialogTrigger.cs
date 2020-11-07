using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DialogTrigger : MonoBehaviour
{
    [Serializable]
    class listData
    {
        public string key;
        public List<GameTrigger> gameTriggers;
    }

    [SerializeField] private List<listData> _triggers;

    public void ActivateTriggers(string keyToFind)
    {
        var keyMatch = _triggers.Find(x => x.key == keyToFind);
        if (keyToFind != null)
        {
            foreach (GameTrigger trigger in keyMatch.gameTriggers)
            {
                trigger.ActivateTrigger();
            }
        }
        else
        {
            throw new Exception("Cant find any trigger by key");
        }
    }
}
