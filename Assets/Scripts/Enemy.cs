using UnityEngine;

public class Enemy : MonoBehaviour
{
    private IBehaviour _currentBehaviour;
    private IBehaviour _idleBehaviour;
    private IBehaviour _agringBehaviour;

    private float _speed = 5f;
    private const float _minDistanceToTarget = 10f;

    private Mover _mover;

    private Rotator _rotator;

    private Character _character;

    public void Initialize(IBehaviour defaultBehaviour, IBehaviour agringBehaviour, Character character)
    {
        _idleBehaviour = defaultBehaviour;
        _agringBehaviour = agringBehaviour;
        _currentBehaviour = defaultBehaviour;

        _character = character;

        _mover = GetComponent<Mover>();

        _rotator = GetComponent<Rotator>();
    }

    private void FixedUpdate()
    {
        if(Vector3.Distance(transform.position, _character.transform.position) <= _minDistanceToTarget)
            SwitchBehaviour(_agringBehaviour);
        else 
            SwitchBehaviour(_idleBehaviour);

        Vector3 currentDirection = _currentBehaviour.Direction() * Time.deltaTime * _speed;

        _mover.SetDirection(currentDirection, Space.World);

        _rotator.SetRotation(transform, currentDirection.x, currentDirection.y);
    }

    private void SwitchBehaviour(IBehaviour behaviour)
    {     
        _currentBehaviour = behaviour;
        _currentBehaviour.Enter();
    }
}
