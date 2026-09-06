using System;
using GUI.Buttons;
using UnityEngine;
using UnityEngine.Events;

namespace GUI.Screens
{
  public class SettingsScreen : Screen
  {
    public event Action OnSettingsClose;
    
    [SerializeField] private BackButton _backButton;
    
    public override void Open()
    {
      _backButton.OnBackButtonClick += BackButtonClick;
    }

    public override void Close()
    {
      _backButton.OnBackButtonClick -= BackButtonClick;
    }

    private void BackButtonClick() => 
      OnSettingsClose?.Invoke();
  }
}