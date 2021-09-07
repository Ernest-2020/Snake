using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : InteractiveObject
{
    public event Action<string> _finish = delegate (string str) { };
    public override void Execute()
    {
        
    }

    protected override void Interaction()
    {
        Time.timeScale = 0.0f;
        _finish.Invoke("Победа!");
    }

    protected override void Magnet()
    {
        
    }
}
