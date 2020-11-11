using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FontChageSC : MonoBehaviour
{
    public Font font;
    void Start()
    {
        var textComponents = Component.FindObjectsOfType<Text>();
        foreach (var component in textComponents)
            component.font = font;
    }

}
