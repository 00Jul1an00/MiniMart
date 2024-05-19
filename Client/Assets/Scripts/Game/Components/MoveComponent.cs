using UnityEngine;

public class MoveComponent : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed;

    public void MoveByRigidbodyVelocityAndRotate(Vector3 direction)
    {
        var nextPosition = _rb.position + direction * _speed;
        _rb.MovePosition(nextPosition);

        if (direction.x != 0 || direction.z != 0)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}