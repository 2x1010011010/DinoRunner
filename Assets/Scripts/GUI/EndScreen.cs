﻿using UnityEngine;
using UnityEngine.Events;

public class EndScreen : Screen
{
    public event UnityAction RestartButtonClick;
    public override void Close()
    {
        CanvasGroup.alpha = 0;
        Button.interactable = false;
    }

    public override void Open()
    {
        CanvasGroup.alpha = 1;
        Button.interactable = true;
    }

    protected override void OnButtonClick()
    {
        RestartButtonClick?.Invoke();
    }
}
