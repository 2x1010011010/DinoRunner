using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StartScreen : Screen
{
    [SerializeField] private Button _settingsButton;
    public event UnityAction PlayButtonClick;

    public override void Close()
    {
        CanvasGroup.alpha = 0;
        Button.interactable = false;
        _settingsButton.interactable = false;
    }

    public override void Open()
    {
        CanvasGroup.alpha = 1;
        Button.interactable = true;
        _settingsButton.interactable = true;
    }

    protected override void OnButtonClick()
    {
        PlayButtonClick?.Invoke();
    }
}
