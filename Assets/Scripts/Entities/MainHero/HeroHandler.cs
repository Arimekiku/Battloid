using UnityEngine;

public class HeroHandler : IUpdatable
{
    private readonly HeroBehaviour _heroBehaviour;

    private Vector2 _horizontalInput;
    private Vector2 _verticalInput;

    public HeroHandler(BindProvider bindProvider, HeroBehaviour heroBehaviour)
    {
        _heroBehaviour = heroBehaviour;

        bindProvider.GetBindOfType(BindType.Dash).PressBindAction += _heroBehaviour.Dash;
        bindProvider.GetBindOfType(BindType.Interact).PressBindAction += _heroBehaviour.Interact;
        
        bindProvider.GetBindOfType(BindType.MoveLeft).PressBindAction += () => { SetNegativeInputValue(ref _horizontalInput, -1); };
        bindProvider.GetBindOfType(BindType.MoveLeft).ReleaseBindAction += () => { SetNegativeInputValue(ref _horizontalInput, 0); };

        bindProvider.GetBindOfType(BindType.MoveRight).PressBindAction += () => { SetPositiveInputValue(ref _horizontalInput, 1); };
        bindProvider.GetBindOfType(BindType.MoveRight).ReleaseBindAction += () => { SetPositiveInputValue(ref _horizontalInput, 0); };

        bindProvider.GetBindOfType(BindType.MoveDown).PressBindAction += () => { SetNegativeInputValue(ref _verticalInput, -1); };
        bindProvider.GetBindOfType(BindType.MoveDown).ReleaseBindAction += () => { SetNegativeInputValue(ref _verticalInput, 0); };
        
        bindProvider.GetBindOfType(BindType.MoveUp).PressBindAction += () => { SetPositiveInputValue(ref _verticalInput, 1); };
        bindProvider.GetBindOfType(BindType.MoveUp).ReleaseBindAction += () => { SetPositiveInputValue(ref _verticalInput, 0); };
    }
    
    public void Update()
    {
        _heroBehaviour.MoveHero();
    }

    private void SetPositiveInputValue(ref Vector2 inputVector, int value)
    {
        inputVector = new Vector2(value, inputVector.y);
        CalculateMovementVector();
    }
    
    private void SetNegativeInputValue(ref Vector2 inputVector, int value)
    {
        inputVector = new Vector2(inputVector.x, value);
        CalculateMovementVector();
    }

    private void CalculateMovementVector()
    {
        float horizontalValue = _horizontalInput.x + _horizontalInput.y;
        float verticalValue = _verticalInput.x + _verticalInput.y;

        var resultInputMap = new Vector2(horizontalValue, verticalValue);
        _heroBehaviour.UpdateMovementVector(resultInputMap);
    }
}