using System;

namespace GUI.Buttons
{
  public class PauseButton : ButtonBase
  {
    public event Action OnPauseClick;

    protected override void ButtonClick() =>
      OnPauseClick?.Invoke();
  }
}