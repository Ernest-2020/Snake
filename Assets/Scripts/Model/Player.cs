using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : PlayerBase
{
    [SerializeField]
    private List<GameObject> _tail;
    [SerializeField]
    private float _boneDistance;
    [SerializeField]
    private GameObject FeverCollider;
    private Rigidbody _rigibodyPlayer;
    private Transform _transform;
    public Color _color;
    public Color _playerColor;
    
    void Start()
    {   _rigibodyPlayer = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
        _tail = new List<GameObject>();
        _tail.Add(GameObject.Find("Tail (0)"));
        _tail.Add(GameObject.Find("Tail (1)"));
        _tail.Add(GameObject.Find("Tail (2)"));
        _tail.Add(GameObject.Find("Tail (3)"));
        _tail.Add(GameObject.Find("Tail (4)"));
    }

    public override void Move(float x, float y, float z)
    {   if(!_isfever )
        _rigibodyPlayer.velocity = new Vector3(x,y,z)*_speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Yellow"))
        {
            _intColor=1;
            _color = GameObject.Find("WallYellow").GetComponent<Renderer>().material.color;
            gameObject.GetComponent<Renderer>().material.color = _color;
            ColorTail();
        }
        if (other.CompareTag("Blue"))
        {
            _intColor = 2;
            _color = GameObject.Find("WallBlue").GetComponent<Renderer>().material.color.gamma;
            gameObject.GetComponent<Renderer>().material.color = _color;
            ColorTail();
        }
        if (other.CompareTag("Orange"))
        {
            _intColor = 3;
            _color = GameObject.Find("WallOrange").GetComponent<Renderer>().material.color;
            gameObject.GetComponent<Renderer>().material.color = _color;
            ColorTail();
        }
        if (other.CompareTag("Red"))
        {
            _intColor = 4;
            _color = GameObject.Find("WallRed").GetComponent<Renderer>().material.color;
            gameObject.GetComponent<Renderer>().material.color = _color;
            ColorTail();
        }
        if (other.CompareTag("Violet"))
        {
            _intColor = 5;
            _color = GameObject.Find("WallViolet").GetComponent<Renderer>().material.color;
            gameObject.GetComponent<Renderer>().material.color = _color;
            ColorTail();
        }
        if (other.CompareTag("Green"))
        {
            _intColor = 6;
            _color = GameObject.Find("WallGreen").GetComponent<Renderer>().material.color;
            gameObject.GetComponent<Renderer>().material.color = _color;
            ColorTail();
        }  
    }


    private void ColorTail()
    {
        foreach (var item in _tail)
        {
            item.GetComponent<Renderer>().material.color = _color;
        }
    }
    public override void TailMove()
    {
        float sqrDistance = Mathf.Sqrt(_boneDistance);
        Vector3 previousPosition = transform.position;
        foreach (var bone in _tail)
        {
            if ((bone.transform.position - previousPosition).sqrMagnitude > sqrDistance)
            {
                Vector3 currentBonePosition = bone.transform.position;
                bone.transform.position = previousPosition;
                previousPosition = currentBonePosition;
            }
            else
            {
                break;
            }
        }
    }

    public override void FeverMove(float x, float y, float z)
    {
        if (_gems >= 3)
        {
            _isfever = true;
            _gems = 0;
            FeverCollider.SetActive(true);
            StartCoroutine(WaitFever());
            _transform.position = new Vector3(0,_transform.position.y,_transform.position.z);
            _rigibodyPlayer.velocity = new Vector3(x, y, z) * (_speed * _feverSpeed);
            
        }
        
    }

    IEnumerator WaitFever()
    {
        yield return new WaitForSeconds(_timeFever);
        _isfever = false;
        FeverCollider.SetActive(false);
    }
}
