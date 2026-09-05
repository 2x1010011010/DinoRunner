using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsButton : MonoBehaviour
{
    [SerializeField] private GameObject _settingsCanvas;
    [SerializeField] private GameObject _mainCanvas;
    [SerializeField] private StartScreen _startScreen;
    public void OnButtonClick()
    {
        _startScreen.Close();
        _mainCanvas.SetActive(false);
        _settingsCanvas.SetActive(true);
    }
}
