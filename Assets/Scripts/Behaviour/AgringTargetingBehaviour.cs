using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgringTargetingBehaviour : IBehaviour
{
    private Vector3 _direction;
    private readonly Transform _targetTransform;
    private readonly Transform _transform;


    public AgringTargetingBehaviour(Transform transform, Transform targetTransform)
    {
        _transform = transform;
        _targetTransform = targetTransform;
    }

    public Vector3 Direction()
    {
        return _direction;
    }

    public void Enter()
    {

        Update();
    }

    public void Update()
    {
        _direction = (_targetTransform.position - _transform.position).normalized;
    }
}
