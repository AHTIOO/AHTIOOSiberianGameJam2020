using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AuthorsControl : MonoBehaviour
{
    public Texture2D cursor;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot;
    public GameObject Current;
    public GameObject mainMenu;

    public void SetCurcor()
    {
        Cursor.SetCursor(cursor, hotSpot, cursorMode);
    }

    public void SetCursirDefault()
    {
        Cursor.SetCursor(null, hotSpot, cursorMode);
    }

    public void GoToLink(string link)
    {
        Application.OpenURL(link);
    }
    public void GoToMainMenu()
    {
        mainMenu.SetActive(true);
        Current.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
