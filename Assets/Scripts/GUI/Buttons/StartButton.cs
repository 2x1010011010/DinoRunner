using System;

namespace GUI.Buttons
{
  public class StartButton : ButtonBase
  {
    public event Action OnStartButtonClicked;
    
    protected override void ButtonClick()
    {
      OnStartButtonClicked?.Invoke();
    }
  }
}