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
    [SerializeField] private Player _player;
    [SerializeField] private GameUIObserver _gameUIObserver;
    [SerializeField] private Score _score;
  }
}