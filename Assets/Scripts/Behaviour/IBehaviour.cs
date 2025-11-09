using UnityEngine;

public interface IBehaviour
{
    public Vector3 Direction()
    {
        return Vector3.zero;
    }
    
    public void Enter() { }

    public void Update() { }

    public void Exit() { }
}
