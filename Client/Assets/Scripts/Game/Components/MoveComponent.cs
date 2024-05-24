using UnityEngine;

public class MoveComponent
{
    private Rigidbody _rb;
    private float _speed;

    public MoveComponent(Rigidbody rb, float baseSpeed)
    {
        _rb = rb;
        _speed = baseSpeed;
    }

    public void MoveByRigidbodyVelocityAndRotate(Vector3 direction)
    {
        var nextPosition = _rb.position + direction * _speed;
        _rb.MovePosition(nextPosition);

        if (direction.x != 0 || direction.z != 0)
        {
            _rb.transform.rotation = Quaternion.LookRotation(direction);
        }
    }

    public void IncreaseSpeed(float increaseBy)
    {
        _speed += increaseBy;
    }
}