using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBase : MonoBehaviour
{
    public float _speed;
    public static int _peoplePoint;
    public static int _intColor;
    public static bool _isfever;
    public static int _gems;
    public float _feverSpeed;
    public float _timeFever;

    public abstract void Move(float x, float y, float z);
    public abstract void TailMove();
    public abstract void FeverMove(float x, float y, float z);
}
