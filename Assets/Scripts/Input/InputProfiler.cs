using System.Collections.Generic;

public class InputProfiler : IUpdatable, IInputProfileChanger
{
    private readonly Dictionary<ProfileType, InputProfile> _profiles = new();
    private InputProfile _currentProfile;

    private readonly UIHandler _uiHandler;
    private readonly PauseProfile _pauseProfile;
    private readonly UnpauseProfile _unpauseProfile;

    public InputProfiler(UIHandler uiHandler, MainHeroBehaviour mainHero)
    {
        var actionProvider = new ActionProvider();
        
        _unpauseProfile = new UnpauseProfile(mainHero, actionProvider);
        _profiles.Add(ProfileType.UnpauseInputProfile, _unpauseProfile);

        _pauseProfile = new PauseProfile(actionProvider);
        _profiles.Add(ProfileType.PauseInputProfile, _pauseProfile);
        
        ChangeProfile(ProfileType.UnpauseInputProfile);
        _uiHandler = uiHandler;
        
        _uiHandler.ContinueButton.onClick.AddListener(Unpause);
        _uiHandler.ControlsButton.onClick.AddListener(OnControlsOpened);

        _unpauseProfile.OnPausePressed += Pause;
    }
    
    public void Update()
    {
        _currentProfile?.Update();
    }

    public void AddProfile(ProfileType type, InputProfile profile)
    {
        _profiles.Add(type, profile);
    }
    
    public void ChangeProfile(ProfileType type)
    {
        _currentProfile = _profiles[type];
    }
    
    private void OnControlsClosed()
    {
        _pauseProfile.OnPausePressed += Unpause;
        _pauseProfile.OnPausePressed -= _uiHandler.CloseControlsMenu;
        _pauseProfile.OnPausePressed -= OnControlsClosed;
    }

    private void OnControlsOpened()
    {
        _pauseProfile.OnPausePressed -= Unpause;
        _pauseProfile.OnPausePressed += _uiHandler.CloseControlsMenu;
        _pauseProfile.OnPausePressed += OnControlsClosed;
    }

    private void Unpause()
    {
        _uiHandler.ClosePauseMenu();
        ChangeProfile(ProfileType.UnpauseInputProfile);
    }

    private void Pause()
    {
        _uiHandler.OpenPauseMenu();
        ChangeProfile(ProfileType.PauseInputProfile);
    }
}