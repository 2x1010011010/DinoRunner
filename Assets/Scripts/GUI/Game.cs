using System.Collections.Generic;
using Cacti;
using Dinosaur;
using GUI.Screens;
using UnityEngine;
using UnityEngine.Serialization;

namespace GUI
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private Player player;
        [SerializeField] private DinosaurMover _dinosaurMover;
        [SerializeField] private GroundMover _groundMover;
        [SerializeField] private List<Spawner> _spawners;

        private void OnEnable()
        {
            player.GameOver += OnGameOver;
        }

        private void OnDisable()
        {
            player.GameOver -= OnGameOver;
        }

        private void Start()
        {
            Time.timeScale = 0;
        }

        private void OnPlayButtonClick()
        {
            StartGame(false);
        }
    
        private void OnRestartButtonClick()
        {
        
            foreach(var item in _spawners)
                item.ResetPool();
        
            _dinosaurMover.ResetSpeed();
            StartGame(true);
        }

        private void OnPauseButtonClick()
        {
            Time.timeScale = 0;
        }

        private void StartGame(bool isRestart)
        {
            _dinosaurMover.ResetDinosaurMove();
            Time.timeScale = 1;
            if (isRestart)
            {
                player.ResetPlayer();
            }
        }

        public void OnGameOver()
        {
            Time.timeScale = 0;
        }
    }
}
