using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCaller : MonoBehaviour
{
    [SerializeField] private GameObject _menuParrant;
    private bool isActive = false;
    private GameObject curMenu;
    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && (!isActive))
        {
            curMenu = Instantiate(_menuParrant);
            isActive = !isActive;
        }
        else if (Input.GetKeyUp(KeyCode.Escape) && (isActive))
        {
            Destroy(curMenu);
            isActive = !isActive;
        }
      
    }
}
