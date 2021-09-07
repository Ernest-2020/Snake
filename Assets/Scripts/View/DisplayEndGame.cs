using UnityEngine;
using UnityEngine.UI;
using System;
   public sealed class DisplayEndGame
    {
        private Text _endGameLabel;

        public DisplayEndGame(GameObject endGame, GameObject restartButton, GameObject nextLevel)
        {
            _endGameLabel = endGame.GetComponentInChildren<Text>();
            _endGameLabel.text = String.Empty;
        }

        public void GameOver(string name)
        {
            _endGameLabel.text = $"Game Over!";
        }
        public void FinishGame(string name)
        {
            _endGameLabel.text = $"Победа!";
        }
    }



