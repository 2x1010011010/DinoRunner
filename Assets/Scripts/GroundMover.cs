using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMover : MonoBehaviour
{
    [SerializeField] private Ground[] _groundTemplates;

    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }
    private void Update()
    {
        for(int i = 0; i < _groundTemplates.Length; i++)
        {
            Vector3 point = _camera.WorldToViewportPoint(_groundTemplates[i].transform.position);
            if (point.x < 0)
            {
                _groundTemplates[i].transform.position = new Vector3(_groundTemplates[i].transform.position.x + 51, _groundTemplates[i].transform.position.y, _groundTemplates[i].transform.position.z);
            }
        }
    }
}
