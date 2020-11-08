using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOnButton : MonoBehaviour
{
    [SerializeField] private KeyCode _keyCode;
    [SerializeField] private GameObject _objectToActivate;

    private void Update()
    {
        if (Input.GetKeyUp(_keyCode))
        {
            _objectToActivate.SetActive(!_objectToActivate.activeSelf);
        }
    }
}
