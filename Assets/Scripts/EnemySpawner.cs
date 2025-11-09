using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<SpawnPoint> _spawnPoints;
    [SerializeField] private List<Transform> _patrolPoints;

    [SerializeField] private ParticleSystem _explosion;

    [SerializeField] private Enemy _enemyPrefab;

    [SerializeField] private Character _target;


    private ParticleSystem DeathEffect() => Instantiate(_explosion, transform.position, Quaternion.identity);
    private Enemy CreateEnemy(SpawnPoint spawnPoint) => Instantiate(_enemyPrefab, spawnPoint.transform.position, Quaternion.identity);

    private void Awake()
    {
        foreach(SpawnPoint spawnPoint in _spawnPoints)
        {
            Enemy enemy = CreateEnemy(spawnPoint);

            enemy.Initialize(SelectIdleBehaviour(spawnPoint, enemy.transform), SelectAgringBehaviour(spawnPoint, enemy.transform, _target.transform), _target);

        }
    }

    private IBehaviour SelectIdleBehaviour(SpawnPoint spawnPoint, Transform transform)
    {
        IdleStates idleType = spawnPoint.IdleType;

        switch (idleType)
        {

            case IdleStates.Standing:
                return new IdleStandingBehaviour();
               
            case IdleStates.Patrol:
                return new IdlePatrolBehaviour(_patrolPoints, transform);
                
            case IdleStates.RandomWalk:
               return new IdleRandomWalkBehaviour(transform);

            default:
                return new IdleStandingBehaviour();
        }
    }

    private IBehaviour SelectAgringBehaviour(SpawnPoint spawnPoint, Transform transform, Transform targetTransform)
    {

        AgringStates agringType = spawnPoint.AgringType;

        switch (agringType)
        {
            case AgringStates.Escape:
                return new AgringEscapeBehaviour(transform, targetTransform);
                

            case AgringStates.Targeting:
                return new AgringTargetingBehaviour(transform, targetTransform);
                

            case AgringStates.Diying:
                return new AgringDyingBehaviour(transform, DeathEffect());

            default:
                return new AgringEscapeBehaviour(transform, targetTransform);


        }
    }

    
}
