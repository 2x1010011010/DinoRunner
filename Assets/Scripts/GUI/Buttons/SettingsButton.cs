using System;

namespace GUI.Buttons
{
  public class SettingsButton : ButtonBase
  {
    public event Action OnSettingsButtonClick;

    protected override void ButtonClick()
    {
      OnSettingsButtonClick?.Invoke();
    }
  }
}