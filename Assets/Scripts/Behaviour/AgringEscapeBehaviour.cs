using UnityEngine;

public class AgringEscapeBehaviour : IBehaviour
{
    private Vector3 _direction;
    private readonly Transform _targetTransform;
    private readonly Transform _transform;
    

    public AgringEscapeBehaviour(Transform transform, Transform targetTransform)
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
        _direction = (_transform.position - _targetTransform.position).normalized;
    }

   
}
