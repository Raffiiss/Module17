using UnityEngine;

public class PlayerMovementBehaviour : MonoBehaviour, IMovementBehaviour
{
    public Vector3 GetDirection()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        return new Vector3(0, 0, vertical).normalized;
    }
}
