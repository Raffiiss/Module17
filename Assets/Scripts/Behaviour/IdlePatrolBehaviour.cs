using System.Collections.Generic;
using UnityEngine;

public class IdlePatrolBehaviour : IBehaviour
{
    private List<Transform> _patrolPoints;
    private Transform _targetPoint;
    private readonly Transform _transform;

    private int _currentPointIndex;

    private Vector3 _direction;

    private const float _minTargetDistance = 0.1f;

    public IdlePatrolBehaviour(List<Transform> patrolPoints, Transform transform)
    {
        _patrolPoints = patrolPoints;
        _transform = transform;
        
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
        if (_patrolPoints.Count == 0)
        {
            Debug.LogError("Ќе заданы точки дл€ патрулировани€ врага");
            return;
        }
        _targetPoint = _patrolPoints[_currentPointIndex];

        if (Vector3.Distance(_transform.position, _targetPoint.position) < _minTargetDistance)
        {
            _currentPointIndex++;

            if (_currentPointIndex >= _patrolPoints.Count)
                _currentPointIndex = 0;
        }

        _direction = _targetPoint.position - _transform.position;

    }
}
