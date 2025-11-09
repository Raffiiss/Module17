using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private float _xInput;
    private float _yInput;
    private float _keyboardInput;
    private float _rightBoundary = 50;
    private float _leftBoundary = -50;

    private bool isCursorLocked = true;

    public float KeyBoardInput => _keyboardInput;
    public float XInput  => _xInput;
    public float YInput => _yInput;


    private void HandleCursorInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            LockCursor(!isCursorLocked);
    }

    private void LockCursor(bool locked)
    {
        isCursorLocked = locked;

        if(locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState= CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void HandleMouseLook()
    {
        float aroundXRotation = Input.GetAxis("Mouse X");
        float aroundYRotation = Input.GetAxis("Mouse Y");

        _xInput -= aroundYRotation;
        _yInput += aroundXRotation;

        if (_xInput > _rightBoundary)
            _xInput = _rightBoundary;

        if (_xInput < _leftBoundary)
            _xInput = _leftBoundary;
    }

    private void HandleKeyboardMovement()
    {
        _keyboardInput = Input.GetAxis("Vertical");
    }

    private void Update()
    {
        HandleMouseLook();
        HandleKeyboardMovement();
        LockCursor(isCursorLocked);
    }
}
