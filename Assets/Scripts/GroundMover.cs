using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMover : MonoBehaviour
{
    [SerializeField] private List<GameObject> _groundTemplates;
    [SerializeField] private float _positionDelta;
    [SerializeField] private float _borderAbroadCamera;

    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }
    private void Update()
    {
        for(int i = 0; i < _groundTemplates.Count; i++)
        {
            Vector3 point = _camera.WorldToViewportPoint(_groundTemplates[i].transform.position);
            if (point.x < _borderAbroadCamera)
            {
                _groundTemplates[i].transform.position = new Vector3(_groundTemplates[i].transform.position.x + _positionDelta, _groundTemplates[i].transform.position.y, _groundTemplates[i].transform.position.z);
            }
        }
    }
}
