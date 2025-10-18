using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    [SerializeField] private EnemyIdleStates _idleState;
    [SerializeField] private EnemyAgringStates _agringState;

    public EnemyIdleStates IdleState => _idleState;
    public EnemyAgringStates AgringState => _agringState;
}
