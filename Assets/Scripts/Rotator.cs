using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private float _xRotation;
    private float _yRotation;

    private Transform _transform;

    public void SetRotation(Transform transform, float xRotation, float yRotation)
    {
        _transform = transform;
        _xRotation = xRotation;
        _yRotation = yRotation;
    }

    private void FixedUpdate()
    {
        _transform.rotation = Quaternion.Euler(_xRotation, _yRotation, 0);
    }
}
