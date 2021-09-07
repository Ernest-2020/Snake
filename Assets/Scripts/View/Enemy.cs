using System;
using UnityEngine;

public class Enemy : InteractiveObject
{
    public event Action<string> OnCaughtPlayerChange = delegate (string str) { };
    public delegate void CaughtPlauerChange();
    public CaughtPlauerChange CaughtPlayer;
    public override void Execute()
    {
        
    }

    protected override void Interaction()
    {
        if (!Player._isfever) 
        {
            Time.timeScale = 0;
            OnCaughtPlayerChange?.Invoke("");
            CaughtPlayer?.Invoke();
        }
        return;
    }

    protected override void Magnet()
    {
        
    }
}
