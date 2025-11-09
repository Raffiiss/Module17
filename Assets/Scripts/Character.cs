using System;
using UnityEngine;

public class Character : MonoBehaviour
{
    private const float YPosition = 1.59f;
    private float _movementSpeed = 55f;  

    private Vector3 _direction;

    private Mover _mover;

    private Rotator _rotator;

    private InputHandler _inputHandler;
    
    private void Awake()
    {
        _inputHandler = GetComponent<InputHandler>();
        _mover = GetComponent<Mover>();
        _rotator = GetComponent<Rotator>();

        _rotator.SetRotation(transform, _inputHandler.XInput, _inputHandler.YInput);
    }

    private void Update()
    {
        _direction = Vector3.forward * _inputHandler.KeyBoardInput * _movementSpeed * Time.deltaTime;

        _mover.SetDirection(_direction, Space.Self);

       _rotator.SetRotation(transform, _inputHandler.XInput, _inputHandler.YInput);    
    }

    private void FixedUpdate() => transform.position = new Vector3(transform.position.x, YPosition, transform.position.z);
}
