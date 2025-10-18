using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementBehaviour : MonoBehaviour, IMovementBehaviour
{
    private int currentPointIndex = 0;
    private float _timer = 0;
    private const float _maxDistance = 10f;
    private const float _agreDistance = 18f;

    [SerializeField] private ParticleSystem explosionPrefab;
    [SerializeField] private List<Transform> patrolPoints;
    private Transform characterTransform;

    private Transform _targetPoint;
    private EnemyState enemyState;
    private Vector3 _direction;
    private Vector3 _startPos;


    public Transform TargetPoint => _targetPoint;
    public Vector3 Direction => _direction;
    private void Awake()
    {
        characterTransform = GameObject.FindGameObjectWithTag("Player").transform;
        enemyState = GetComponent<EnemyState>();
    }

    private void Start()
    {
        
        _startPos = transform.position;
    }

    public Vector3 GetDirection()
    {
        if (Vector3.Distance(transform.position, characterTransform.position) < _agreDistance)           
            GetAgroDirection();       
        else
            GetIdleDirection();

            return _direction;
    }

    private void GetAgroDirection()
    {
        
        switch (enemyState.AgringState)
        {
            case EnemyAgringStates.Escape:
               _direction =  (transform.position - characterTransform.position).normalized;
                break;

            case EnemyAgringStates.Targeting:
               _direction = (characterTransform.position - transform.position).normalized;
                break;

            case EnemyAgringStates.Diying:
                Die();
                break;

            default:
                Debug.LogError("Не найдено состояние агра для врага");
                break;
        }
    }

    private void GetIdleDirection()
    {
        
        switch (enemyState.IdleState)
        {

            case EnemyIdleStates.Standing:
                _direction = Vector3.zero;
                break;

            case EnemyIdleStates.Patrol:
                if (patrolPoints.Count == 0)
                {
                    Debug.LogError("Не заданы точки для патрулирования врага");
                    break;
                }

                _targetPoint = patrolPoints[currentPointIndex];

                if (Vector3.Distance(transform.position, _targetPoint.position) < 0.1f)
                {

                    currentPointIndex++;

                    if (currentPointIndex >= patrolPoints.Count)
                        currentPointIndex = 0;
                }

                _direction = _targetPoint.position - transform.position;
                break;

            case EnemyIdleStates.RandomWalk:
                break;

            default:
                Debug.LogError("Не найдено состояние покоя для врага");
                break;
        }
    }

    private void UpdateRandomWalkTimer()
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

        if (Vector3.Distance(transform.position, _startPos) > _maxDistance)
            _direction = (_startPos - transform.position).normalized;
    }

    private void Update()
    {
        if (enemyState.IdleState == EnemyIdleStates.RandomWalk)
            UpdateRandomWalkTimer();
    }

    private void Die()
    {

        if (explosionPrefab != null)
        {
            ParticleSystem explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            explosion.Play();
            Destroy(explosion.gameObject, explosion.main.duration);
        }
        else
            Debug.LogError("Партикл смерти врага не найден");

            Destroy(gameObject); 
    }
}
