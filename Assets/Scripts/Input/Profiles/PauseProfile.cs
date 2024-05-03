using System;
using UnityEngine;

public class PauseProfile : InputProfile
{
    public event Action OnPausePressed;
    
    public PauseProfile(ActionProvider provider) : base(provider)
    {
        
    }
    
    public override void Update()
    {
        if (Input.GetKeyDown(Provider.GetControl(KeysAction.PauseUnpause)))
            OnPausePressed?.Invoke();
    }
}