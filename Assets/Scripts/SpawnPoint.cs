using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
   
    [SerializeField] private IdleStates _idleType;

    [SerializeField] private AgringStates _agringType;

    public IdleStates IdleType => _idleType;
    public AgringStates AgringType => _agringType;
    
}
