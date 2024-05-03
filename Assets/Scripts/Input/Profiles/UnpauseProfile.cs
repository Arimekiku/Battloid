using System;
using UnityEngine;

public class UnpauseProfile : InputProfile
{
    private event Action<Vector2Int> OnMovePressed;
    public event Action OnPausePressed;
    private event Action OnDashPressed;
    private event Action OnActionPressed;
    
    private event Action OnLMBPressed;
    private event Action OnLMBHolded;
    private event Action OnLMBReleased;
    private event Action OnRMBPressed;

    public UnpauseProfile(MainHeroBehaviour mainHero,
        ActionProvider provider) : base(provider)
    {
    }
    
    public override void Update()
    {
        if (Input.GetKeyDown(Provider.GetControl(KeysAction.PauseUnpause)))
            OnPausePressed?.Invoke();
        
        if (Input.GetKeyDown(Provider.GetControl(KeysAction.Dash)))
            OnDashPressed?.Invoke();
        
        if (Input.GetKeyDown(Provider.GetControl(KeysAction.Action)))
            OnActionPressed?.Invoke();

        var moveVector = GetMovementVector();
        if (moveVector != Vector2Int.zero) 
            OnMovePressed?.Invoke(moveVector);
    }

    private Vector2Int GetMovementVector()
    {
        bool isMovingLeft = Input.GetKey(Provider.GetControl(KeysAction.MoveLeft));
        int horizontalValue = 0;
        bool isMovingDown = Input.GetKey(Provider.GetControl(KeysAction.MoveDown));
        int verticalValue = 0;

        if (isMovingLeft ^ Input.GetKey(Provider.GetControl(KeysAction.MoveLeft)))
            horizontalValue = isMovingLeft ? -1 : 1;

        if (isMovingDown ^ Input.GetKey(Provider.GetControl(KeysAction.MoveUp)))
            verticalValue = isMovingDown ? -1 : 1;

        return new Vector2Int(horizontalValue, verticalValue);
    }
}