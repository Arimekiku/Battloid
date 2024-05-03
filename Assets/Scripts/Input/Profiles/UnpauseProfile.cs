using System;
using UnityEngine;

public class UnpauseProfile : InputProfile
{
    private event Action<Vector2Int> OnMovePressed;
    private event Action OnPausePressed;
    private event Action OnDashPressed;
    private event Action OnActionPressed;
    
    private event Action OnLMBPressed;
    private event Action OnLMBHolded;
    private event Action OnLMBReleased;
    private event Action OnRMBPressed;

    public UnpauseProfile(MainHeroBehaviour mainHero, UIHandler uiHandler, 
        ActionMap map, IInputProfileChanger profileChanger) : base(map, profileChanger)
    {
        OnPausePressed += Pause;
        
        //TODO: make all actions work

        void Pause()
        {
            uiHandler.OpenPauseMenu();
            ProfileChanger.ChangeProfile(ProfileType.PauseInputProfile);
        }
    }
    
    public override void Update()
    {
        if (Input.GetKeyDown(Map.GetControl(KeysAction.PauseUnpause)))
            OnPausePressed?.Invoke();
        
        if (Input.GetKeyDown(Map.GetControl(KeysAction.Dash)))
            OnDashPressed?.Invoke();
        
        if (Input.GetKeyDown(Map.GetControl(KeysAction.Action)))
            OnActionPressed?.Invoke();

        var moveVector = GetMovementVector();
        if (moveVector != Vector2Int.zero) 
            OnMovePressed?.Invoke(moveVector);
    }

    private Vector2Int GetMovementVector()
    {
        bool isMovingLeft = Input.GetKey(Map.GetControl(KeysAction.MoveLeft));
        int horizontalValue = 0;
        bool isMovingDown = Input.GetKey(Map.GetControl(KeysAction.MoveDown));
        int verticalValue = 0;

        if (isMovingLeft ^ Input.GetKey(Map.GetControl(KeysAction.MoveLeft)))
            horizontalValue = isMovingLeft ? -1 : 1;

        if (isMovingDown ^ Input.GetKey(Map.GetControl(KeysAction.MoveUp)))
            verticalValue = isMovingDown ? -1 : 1;

        return new Vector2Int(horizontalValue, verticalValue);
    }
}