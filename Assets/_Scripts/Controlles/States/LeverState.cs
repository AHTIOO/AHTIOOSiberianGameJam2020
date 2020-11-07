using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverState
{
    public bool IsWork { get; set; }

    public LeverState(Lever lever)
    {
        IsWork = lever.IsWorkByDefault;
    }
}
