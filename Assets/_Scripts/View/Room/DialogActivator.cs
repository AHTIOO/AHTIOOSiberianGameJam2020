using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogActivator : MonoBehaviour
{
    public Action<int> OnTalkClicked = (i => { }); 

    [SerializeField] private List<Button> _talkButtons = new List<Button>();

    public void SetAmountOfButtons(List<Character> _characters)
    {
        for (int i = 0; i < _talkButtons.Count; i++)
        {
            _talkButtons[i].gameObject.SetActive(i <= _characters.Count - 1);
        }

        for (int i = 0; i < _characters.Count; i++)
        {
            _talkButtons[i].image.sprite = _characters[i].MenuIcon;
        }
    }

    public void InitializeDialog(int talkIndex)
    {
        OnTalkClicked.Invoke(talkIndex);
    }
}
