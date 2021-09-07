using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : IExecute
{
    private readonly Player _player;

    public SnakeController(Player player)
    {
        _player = player;
    }
    public void Execute()
    {
        _player.FeverMove(0,0,1);
        _player.TailMove();
    }
}
