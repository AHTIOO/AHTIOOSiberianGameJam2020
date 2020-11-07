using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogActivator : MonoBehaviour
{
    public Action<int> OnTalkClicked = (i => { }); 

    [SerializeField] private List<Button> _talkButtons = new List<Button>();

    public void SetAmountOfButtons(int amount)
    {
        for (int i = 0; i < _talkButtons.Count; i++)
        {
            _talkButtons[i].gameObject.SetActive(i <= amount - 1);
        }
    }

    public void InitializeDialog(int talkIndex)
    {
        OnTalkClicked.Invoke(talkIndex);
    }
}
