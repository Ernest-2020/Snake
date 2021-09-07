using System;
using UnityEngine;

public class Orange : InteractiveObject
{
    private GameObject _targetPoint;
    public event Action<string> OnCaughtPlayerChange = delegate (string str) { };
    private float _speed;
    public delegate void CaughtPlauerChange();
    public CaughtPlauerChange CaughtPlayer;
    public event Action PeoplePointText;

    private void Start()
    {
        _targetPoint = GameObject.Find("Tail (0)");
        _speed = 1;
    }
    public override void Execute()
    {

    }
    protected override void Interaction()
    {
        if (Player._isfever == true || Player._intColor == 3)
        {
            Player._peoplePoint++;
            PeoplePointText?.Invoke();
        }
        else
        {
            Time.timeScale = 0;
            OnCaughtPlayerChange?.Invoke("");
            CaughtPlayer?.Invoke();
        }
    }

    protected override void Magnet()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPoint.transform.position, _speed);
    }
}
