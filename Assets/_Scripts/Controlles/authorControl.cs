using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class authorControl : MonoBehaviour
{
    [SerializeField]private GameObject _mainMenu;
    [SerializeField]private GameObject _authors;

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    public void GoToLink(string link)
    {
        Application.OpenURL(link);
    }
    public void SetCursor()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }
    public void SetCursorDefault()
    {
        Cursor.SetCursor(null, hotSpot, cursorMode);
    }
    public void GoToMainMenu()
    {
        _mainMenu.SetActive(true);
        _authors.SetActive(false);
        
    }
    public void CloseGame()
    {
        Application.Quit();
    }
}
