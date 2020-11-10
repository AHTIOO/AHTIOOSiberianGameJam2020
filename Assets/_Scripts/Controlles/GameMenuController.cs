using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuController : MonoBehaviour
{
    public GameObject GameMenu;
    public void Continue()
    {
        Destroy(this.gameObject);
    }
    public void Exin()
    {
        Application.Quit();
    }
}
