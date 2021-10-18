using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DinosaurTracker : MonoBehaviour
{
    [SerializeField] private Dinosaur _target;
    [SerializeField] private float _offsetX;

    private void Update()
    {
        transform.position = new Vector3(_target.transform.position.x + _offsetX, transform.position.y, transform.position.z);
    }
}
