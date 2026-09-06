using System;

namespace GUI.Buttons
{
  public class BackButton : ButtonBase
  {
    public event Action OnBackButtonClick; 
  
    protected override void ButtonClick()
    {
      OnBackButtonClick?.Invoke();
    }
  }
}
