using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private Joystick _joystick;
    private CameraController _cameraController;
    private ListExecuteObject _interactiveObject;
    private SnakeController _snakeController;
    private InputController _inputController;
    private Reference _reference;
    private DisplayEndGame _displayEndGame;
    [SerializeField]
    private TMP_Text _peoplePointText;

    [SerializeField]
    private TMP_Text _gemCountText;

    private void Awake()
    {
        _interactiveObject = new ListExecuteObject();
        _reference = new Reference();
        

        _cameraController = new CameraController(_reference.Player.transform, _reference.MainCamera.transform);
        _interactiveObject.AddExecuteObject(_cameraController);

        _inputController = new InputController(_reference.Player, _joystick);
        _interactiveObject.AddExecuteObject(_inputController);

        _snakeController = new SnakeController(_reference.Player);
        _interactiveObject.AddExecuteObject(_snakeController);

        _displayEndGame = new DisplayEndGame(_reference.EndGame, _reference.ButtonRestart,_reference.NextLEvelButton);

        foreach (var o in _interactiveObject)
        {
            if (o is Enemy enemy)
            {
                enemy.OnCaughtPlayerChange += CaughtPlayer;
                enemy.OnCaughtPlayerChange += _displayEndGame.GameOver;
            }
            if (o is Blue blue)
            {
                blue.OnCaughtPlayerChange += CaughtPlayer;
                blue.OnCaughtPlayerChange += _displayEndGame.GameOver;
                blue.PeoplePointText += RefresPointText;
            }
            if (o is Orange orange)
            {
                orange.OnCaughtPlayerChange += CaughtPlayer;
                orange.OnCaughtPlayerChange += _displayEndGame.GameOver;
                orange.PeoplePointText += RefresPointText;
            }
            if (o is Yellow yellow)
            {
                yellow.OnCaughtPlayerChange += CaughtPlayer;
                yellow.OnCaughtPlayerChange += _displayEndGame.GameOver;
                yellow.PeoplePointText += RefresPointText;
            }
            if (o is Red red)
            {
                red.OnCaughtPlayerChange += CaughtPlayer;
                red.OnCaughtPlayerChange += _displayEndGame.GameOver;
                red.PeoplePointText += RefresPointText;
            }
            if (o is Violet violet)
            {
                violet.OnCaughtPlayerChange += CaughtPlayer;
                violet.OnCaughtPlayerChange += _displayEndGame.GameOver;
                violet.PeoplePointText += RefresPointText;
            }
            if (o is Green green)
            {
                green.OnCaughtPlayerChange += CaughtPlayer;
                green.OnCaughtPlayerChange += _displayEndGame.GameOver;
                green.PeoplePointText += RefresPointText;
            }
            if (o is Finish finish)
            {
                finish._finish += Finish;
                finish._finish += _displayEndGame.FinishGame;
            }
            if (o is Gem gem)
            {
                gem.GemCountText += RefreshGemText;
            }

        }
    }
    void FixedUpdate()
    {
        for (var i = 0; i < _interactiveObject.Length; i++)
        {
            var interactiveObject = _interactiveObject[i];

            if (interactiveObject == null)
            {
                continue;
            }
            interactiveObject.Execute();
        }

    }

    private void RefreshGemText()
    {
        _gemCountText.text = $"Gems: {Player._gems}";
    }
    private void RefresPointText()
    {
        _peoplePointText.text = $"Points: {Player._peoplePoint}";
    }
private void RestartGame()
    {
        SceneManager.LoadScene(sceneBuildIndex: 0);
        Time.timeScale = 1.0f;
    }
    private void CaughtPlayer(string value)
    {
        _reference.ButtonRestart.gameObject.SetActive(true);
        Time.timeScale = 0.0f;
    }
    private void Finish(string value)
    {
        _reference.ButtonRestart.gameObject.SetActive(true);
        _reference.NextLEvelButton.gameObject.SetActive(true);
        Time.timeScale = 0.0f;
    }
    private void Dispose()
    {
        foreach (var o in _interactiveObject)
        {
            if (o is Enemy enemy)
            {
                enemy.OnCaughtPlayerChange -= CaughtPlayer;
                enemy.OnCaughtPlayerChange -= _displayEndGame.GameOver;
            }
            if (o is Blue blue)
            {
                blue.OnCaughtPlayerChange -= CaughtPlayer;
                blue.OnCaughtPlayerChange -= _displayEndGame.GameOver;
                blue.PeoplePointText -= RefresPointText;
            }
            if (o is Orange orange)
            {
                orange.OnCaughtPlayerChange -= CaughtPlayer;
                orange.OnCaughtPlayerChange -= _displayEndGame.GameOver;
                orange.PeoplePointText -= RefresPointText;
            }
            if (o is Yellow yellow)
            {
                yellow.OnCaughtPlayerChange -= CaughtPlayer;
                yellow.OnCaughtPlayerChange -= _displayEndGame.GameOver;
                yellow.PeoplePointText -= RefresPointText;
            }
            if (o is Red red)
            {
                red.OnCaughtPlayerChange -= CaughtPlayer;
                red.OnCaughtPlayerChange -= _displayEndGame.GameOver;
                red.PeoplePointText -= RefresPointText;
            }
            if (o is Violet violet)
            {
                violet.OnCaughtPlayerChange -= CaughtPlayer;
                violet.OnCaughtPlayerChange -= _displayEndGame.GameOver;
                violet.PeoplePointText -= RefresPointText;
            }
            if (o is Green green)
            {
                green.OnCaughtPlayerChange -= CaughtPlayer;
                green.OnCaughtPlayerChange -= _displayEndGame.GameOver;
                green.PeoplePointText -= RefresPointText;
            }
            if (o is Finish finish)
            {
                finish._finish -= Finish;
                finish._finish -= _displayEndGame.FinishGame;
            }
            if (o is Gem gem)
            {
                gem.GemCountText -= RefreshGemText;
            }
        }
    }
}
