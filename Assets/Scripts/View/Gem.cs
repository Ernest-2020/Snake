using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : InteractiveObject
{
    public event Action GemCountText;

    private void Start()
    {
        
    }
    public override void Execute()
    {
        
    }

    protected override void Interaction()
    {
        Player._gems++;
        GemCountText?.Invoke();
    }

    protected override void Magnet()
    {

    }
}
