using System;
using GUI.Buttons;
using GUI.Sliders;
using UnityEngine;

namespace GUI.Screens
{
  public class SettingsScreen : Screen
  {
    public event Action OnSettingsClose;
    
    [SerializeField] private BackButton _backButton;
    [SerializeField] private Slider _soundSlider;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _fxSlider;
    
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