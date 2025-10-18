using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotationBehaviour : MonoBehaviour, IRotatable
{
    private EnemyState enemyState;
    private EnemyMovementBehaviour enemyMovementBehaviour;
    private float _rotationSpeed = 300f;
    private void Awake()
    {
        enemyState = GetComponent<EnemyState>();
        enemyMovementBehaviour = GetComponent<EnemyMovementBehaviour>();
    }

    public void Rotate(Transform currentTransform)
    {
        if(enemyState.IdleState != EnemyIdleStates.Standing)
        {
            if(enemyMovementBehaviour.Direction.sqrMagnitude > 0.0001f)
            {
                Vector3 normalizedDirection = enemyMovementBehaviour.Direction.normalized;
                ProcessRotateTo(normalizedDirection);
            }
        }
    }

    private void ProcessRotateTo(Vector3 direction)
    {
        Vector3 xzDirection = new Vector3(direction.x, 0, direction.z);

        Quaternion lookRotation = Quaternion.LookRotation(xzDirection);
        float step = _rotationSpeed * Time.deltaTime;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, step);
    }
}
