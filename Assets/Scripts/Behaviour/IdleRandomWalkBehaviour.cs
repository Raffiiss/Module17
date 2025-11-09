using UnityEngine;
public class IdleRandomWalkBehaviour : IBehaviour
{
    private const float _maxDistance = 10f;
    private float _timer;

    private Vector3 _direction;
    private readonly Vector3 _startPos;
   
    private readonly Transform _transform;

    public IdleRandomWalkBehaviour(Transform transform)
    {
        _transform = transform;
        _startPos = _transform.position;
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
        _timer += Time.deltaTime;

        if (_timer >= 1f)
        {
            Vector3 newDirection;

            do
            {
                newDirection = new Vector3(Random.Range(-2f, 2f), 0, Random.Range(-2f, 2f));
            }

            while (newDirection.sqrMagnitude < 0.1f);

            _direction = newDirection.normalized;
            _timer = 0f;
        }

        if (Vector3.Distance(_transform.position, _startPos) > _maxDistance)
            _direction = (_startPos - _transform.position).normalized;
    }

    public void Exit()
    {
        _direction = Vector3.zero;
        _timer = 0;
    }

    private void UpdateRandomWalkTimer()
    {
        
    }
}
