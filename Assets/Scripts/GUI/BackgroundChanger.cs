using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundChanger : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _background;
    [SerializeField] private List<Sprite> _sprites;

    private int _counter;
    private void Start()
    {
        _background.sprite = _sprites[0];
        _counter = 0;
    }

    public void ChangeBackground()
    {
        if (_counter == _sprites.Count - 1)
        {
            _counter = -1;
        }
        _counter++;
        _background.sprite = _sprites[_counter];
    }
}
