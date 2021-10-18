using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    [SerializeField] private GameObject _settingsCanvas;
    [SerializeField] private GameObject _mainCanvas;
    [SerializeField] private StartScreen _startScreen;
    public void OnButtonClick()
    {
        _mainCanvas.SetActive(true);
        _settingsCanvas.SetActive(false);
        _startScreen.Open();
    }
}
