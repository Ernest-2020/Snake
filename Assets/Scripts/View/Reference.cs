using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reference
{
    private Player _player;
    private Camera _mainCamera;
    private GameObject _restartButton;
    private Canvas _canvas;
    private GameObject _endGame;
    private GameObject _nextLevelButton;


    public Canvas Canvas
    {
        get
        {
            if (_canvas == null)
            {
                _canvas = Object.FindObjectOfType<Canvas>();
            }
            return _canvas;
        }
    }

    public Player Player
    {
        get
        {
            if (_player == null)
            {
                var gameObject = Resources.Load<Player>("HeadSnake");
                _player = Object.Instantiate(gameObject);
            }
            return _player;
        }
    }

    public Camera MainCamera
    {
        get
        {
            if (_mainCamera == null)
            {
                _mainCamera = Camera.main;
            }
            return _mainCamera;
        }
    }

    public GameObject ButtonRestart
    {
        get
        {
            if (_restartButton == null)
            {
                var gameObject = Resources.Load<GameObject>("UI/RestartButton");
                _restartButton = Object.Instantiate(gameObject, Canvas.transform);
            }
            return _restartButton;
        }
    }

    public GameObject EndGame
    {
        get
        {
            if (_endGame == null)
            {
                var gameObject = Resources.Load<GameObject>("UI/GameOver");
                _endGame = Object.Instantiate(gameObject, Canvas.transform);
            }

            return _endGame;
        }
    }

    public GameObject NextLEvelButton
    {
        get
        {
            if (_nextLevelButton == null)
            {
                var gameObject = Resources.Load<GameObject>("UI/ButtonNextLevel");
                _nextLevelButton = Object.Instantiate(gameObject, Canvas.transform);
            }
            return _nextLevelButton;
        }
    }

}
