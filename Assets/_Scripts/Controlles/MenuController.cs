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
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            _menuParrant.SetActive(true);
        }
    }
}
