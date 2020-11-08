using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using VIDE_Data;
using UnityEngine.UI;
using DG.Tweening;

public class EndGameCheck : MonoBehaviour
{
    [SerializeField]private List<InventoryItem> _winIteamList;
    private bool _isGameEnded = false;
    public Image TransitionScreen;
    public float TransitionSpeed = 2f;

    private void Start()
    {
        Inventory.Instance.OnGameInventoryChanged += CheckEndInventory;
        GameTimeHolder.Instance.OnGameTimeChanged += CheckEndTime;
    }
    void CheckEndTime(GameTime time)
    {
         if((time.Hours == GameTimeHolder.Instance.EndGameTime.Hours)&&(time.Minutes >= GameTimeHolder.Instance.EndGameTime.Minutes))
        {
            TransitionScreen.gameObject.SetActive(true);
            TransitionScreen.DOFade(1, TransitionSpeed);
            SceneManager.LoadScene(3);
        }
         else
        {
            _isGameEnded = false;
        }
    }

    void CheckEndInventory(List<InventoryItem> curentInventory)
    {
        int i = 0;
        foreach (InventoryItem item in _winIteamList)
        {
            if (curentInventory.Contains(item))
            {
                i++;
            }
        }
        if (i == _winIteamList.Count)
        {
            CheckCharsAlives();
        }
        
    }

    private int _currentCharToCheck;
    private List<Character> _charactersToCheck;
    private bool isAtLeastOneCharacterAlive;

    void CheckCharsAlives()
    {
        _charactersToCheck = new List<Character>();
        foreach(var ch in HouseState.Instance.GetCharacters())
        {
            _charactersToCheck.Add(ch);
        }
        _currentCharToCheck = 0;

        CheckNextCharacter(null);
        VD.OnEnd += CheckNextCharacter;
    }

    void CheckNextCharacter(VD.NodeData data)
    {
        if (_currentCharToCheck > _charactersToCheck.Count - 1)
        {
            VD.OnEnd -= CheckNextCharacter;
            if (isAtLeastOneCharacterAlive)
            {
                TransitionScreen.gameObject.SetActive(true);
                TransitionScreen.DOFade(1, TransitionSpeed);
                SceneManager.LoadScene(2);
            }
            else
            {
                TransitionScreen.gameObject.SetActive(true);
                TransitionScreen.DOFade(1, TransitionSpeed);
                SceneManager.LoadScene(1); //"EndNoOneAlive"
            }
        }

        if (HouseState.Instance.GetCharacterState(_charactersToCheck[_currentCharToCheck]).IsAlive)
        {
            isAtLeastOneCharacterAlive = true;
            DialogManager.Instance.Begin(_charactersToCheck[_currentCharToCheck].EndGameDialog, _charactersToCheck[_currentCharToCheck], true);

            _currentCharToCheck += 1;
        }
        else
        {
            _currentCharToCheck += 1;
            CheckNextCharacter(data);
        }
    }


    public bool EndGame()
    {
        return _isGameEnded;
    }
}
