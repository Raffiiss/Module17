using UnityEngine;

public class Mover : MonoBehaviour, IMovable
{
    [SerializeField] private float _moveSpeed = 25f;
    private bool  isMoving = false;
    private float _positionY = 1.59f;
    private IMovementBehaviour _movement;
    private IRotatable _rotation;
    private Vector3 _direction;

    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _movement = GetComponent<IMovementBehaviour>();
        _rotation = GetComponent<IRotatable>();

        if (_movement == null)
            Debug.LogError("Не реализуется интерфейс IMovementBehaviour");
        if (_rotation == null)
            Debug.LogError("Не реализуется интерфейс IRotatable"); 
    }

    public void Move(Vector3 direction)
    {
        _direction = direction;
        isMoving = true;
    }

    private void Update()
    {
        HandleInputAndDirection();
        Rotation();
    }

    private void FixedUpdate()
    {
        Moving();
    }

    private void Moving()
    {
        if (_movement != null)
        {
            var direction = _movement.GetDirection();
            if (direction.magnitude > 0)
            {
                Move(direction);
            }
            else
                Stop();

            if(isMoving == true)
                if(gameObject.tag == "Player")
                    transform.Translate(_direction.normalized * _moveSpeed * Time.deltaTime, Space.Self);
                else
                    transform.Translate(_direction.normalized * _moveSpeed * Time.deltaTime, Space.World);

                Vector3 _currentPosition = transform.position;
                _currentPosition.y = _positionY;
                transform.position = _currentPosition;
        }
    }

    private void Rotation() {
        if (_rotation != null)
        {
            _rotation.Rotate(transform);
        }
        else
            return;
    }

    public void Stop()
    {
        isMoving = false;
        _direction = Vector3.zero;
    }

    private void HandleInputAndDirection()
    {
        if (_movement != null)
        {
            var direction = _movement.GetDirection();
            if (direction.magnitude > 0)
            {
                Move(direction);
            }
            else
                Stop();
        }
    }
}
