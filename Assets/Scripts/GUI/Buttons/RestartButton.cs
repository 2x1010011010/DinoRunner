using System;

namespace GUI.Buttons
{
  public class RestartButton : ButtonBase
  {
    public event Action OnRestartButtonClick;
    protected override void ButtonClick() => 
      OnRestartButtonClick?.Invoke();
  }
}