using UnityEngine;

public class HeroBehaviour : MonoBehaviour
{
    private const float MovementSpeed = 10f;
    
    private Rigidbody2D _body;
    private Vector2 _movementVector;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    public void UpdateMovementVector(Vector2 inputMap)
    {
        _movementVector = inputMap.normalized;
    }

    public void MoveHero()
    {
        var nextPosition = _body.position + _movementVector * (MovementSpeed * Time.deltaTime);
        _body.MovePosition(nextPosition);
    }
}