using System;
using UnityEngine;

public class PauseProfile : InputProfile
{
    private event Action OnPauseReleased;
    
    public PauseProfile(UIHandler uiHandler, ActionMap map, IInputProfileChanger profileChanger) : base(map, profileChanger)
    {
        OnPauseReleased += Unpause;

        //TODO: make pause profile work

        void Unpause()
        {
            uiHandler.ClosePauseMenu();
            ProfileChanger.ChangeProfile(ProfileType.UnpauseInputProfile);
        }
    }
    
    public override void Update()
    {
        if (Input.GetKeyDown(Map.GetControl(KeysAction.PauseUnpause)))
            OnPauseReleased?.Invoke();
    }
}