using UnityEngine;

public class AgringDyingBehaviour : IBehaviour
{
    private readonly Transform _transform;

    private readonly ParticleSystem _explosion;

    public AgringDyingBehaviour(Transform transform, ParticleSystem explosion)
    {
        _transform = transform;
        _explosion = explosion;
    }

    public void Enter()
    {
        Die();
    }
    
    private void Die()
    {
        _explosion.transform.position = _transform.position;
        _transform.gameObject.SetActive(false);
        _explosion.Play();
        
    }
}
