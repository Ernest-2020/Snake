using System;
using UnityEngine;

public class Red : InteractiveObject
{
    private GameObject _targetPoint;
    public event Action<string> OnCaughtPlayerChange = delegate (string str) { };
    public event Action PeoplePointText;
    private float _speed;
    public delegate void CaughtPlauerChange();
    public CaughtPlauerChange CaughtPlayer;
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
        if (Player._isfever == true || Player._intColor == 4)
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
