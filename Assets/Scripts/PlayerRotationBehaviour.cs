using UnityEngine;

public class PlayerRotationBehaviour : MonoBehaviour, IRotatable
{
    private float _rightBoundary = 50;
    private float _leftBoundary = -50;
    private float _rotationY = 0;
    private float _rotationX = 0;

    public void Rotate(Transform currentTransform)
    {
        float aroundYRotation = Input.GetAxis("Mouse Y");
        float aroundXRotation = Input.GetAxis("Mouse X");

        _rotationX -= aroundYRotation;
        _rotationY += aroundXRotation;

        if (_rotationX > _rightBoundary)
            _rotationX = _rightBoundary;

        if (_rotationX < _leftBoundary)
            _rotationX = _leftBoundary;

        currentTransform.rotation = Quaternion.Euler(_rotationX, _rotationY, 0);

    }
}
