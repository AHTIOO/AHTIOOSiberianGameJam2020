using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    GameObject GamePrefab = null;
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _newGameButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private GameObject _menuParrant;
    [SerializeField] private GameObject _authors;
    

    void Start()
    {
        if (GamePrefab == null)
        {
            _continueButton.gameObject.SetActive(false);
        }
        else
        {
            _continueButton.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame

    [EditorButton]
    public void StartNewGame()
    {

        if (GamePrefab != null)
            Destroy(GamePrefab);
        GamePrefab = Instantiate(_prefab);
        _newGameButton.gameObject.SetActive(false);
        _menuParrant.SetActive(false);
        _continueButton.gameObject.SetActive(true);
    }
    public void Continue()
    {
        _menuParrant.SetActive(false);
    }
    public void CLoseGame()
    {
        Application.Quit();
    }

    public void ShowAthors()
    {
        _menuParrant.SetActive(false);
        _authors.SetActive(true);
        
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && (!_menuParrant.activeSelf))
        {
            _menuParrant.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.Escape) && (_menuParrant.activeSelf))
        {
            _menuParrant.SetActive(false);
        }
    }
}
