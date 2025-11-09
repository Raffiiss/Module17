using UnityEngine;

public class Mover : MonoBehaviour

{
    private Vector3 _direction;

    private Space _space;

    public void SetDirection(Vector3 direction, Space space)
    {
        _direction = direction;
        _space = space;
    }


    private void FixedUpdate()
    {
        transform.Translate(_direction, _space);
    }
}
