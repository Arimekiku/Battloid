using UnityEngine;

public class HeroBehaviour : MonoBehaviour
{
    private Rigidbody2D _body;
    private float _movementSpeed = 10f;
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
        var nextPosition = _body.position + _movementVector * (_movementSpeed * Time.deltaTime);
        _body.MovePosition(nextPosition);
    }

    public void Dash()
    {
        
    }

    public void Interact()
    {
        
    }
}