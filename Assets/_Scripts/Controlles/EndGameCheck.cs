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

    private int _currentCharToCheck = -1;
    private List<Character> _charactersToCheck;
    private bool isAtLeastOneCharacterAlive;
    VD.NodeData data;

    public void CheckCharsAlives()
    {
        _isGameEnded = true;
        _charactersToCheck = new List<Character>();
        foreach (var ch in HouseState.Instance.GetCharacters())
        {
            _charactersToCheck.Add(ch);
        }
       
    }
    private void Update()
    {
        if ((_isGameEnded) && (Input.GetMouseButton(0)) && (!VD.isActive) && (_currentCharToCheck < _charactersToCheck.Count - 1))
        {
            _currentCharToCheck += 1;
            CheckNextCharacter();
            
        }
    }
    void CheckNextCharacter()
    {
        
        if (_currentCharToCheck > _charactersToCheck.Count - 2)
        {
            
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

        else if (HouseState.Instance.GetCharacterState(_charactersToCheck[_currentCharToCheck]).IsAlive)
        {
            isAtLeastOneCharacterAlive = true;
            DialogManager.Instance.Begin(_charactersToCheck[_currentCharToCheck].EndGameDialog, _charactersToCheck[_currentCharToCheck], true, null);

            
        }
        else
        {
           

        }
    }


    public bool EndGame()
    {
        return _isGameEnded;
    }
}
