public class UIBindSubscriber
{
    private readonly BindProvider _bindProvider;
    private readonly UIHandler _uiHandler;
    
    public UIBindSubscriber(BindProvider bindProvider, UIHandler uiHandler)
    {
        _bindProvider = bindProvider;
        _uiHandler = uiHandler;

        _uiHandler.ContinueButton.onClick.AddListener(Unpause);
        _uiHandler.ControlsButton.onClick.AddListener(OnControlsOpened);

        _bindProvider.GetBindOfType(BindType.PauseUnpause).PressBindAction += Pause;
    }
    
    private void OnControlsClosed()
    {
        _bindProvider.GetBindOfType(BindType.PauseUnpause).PressBindAction += Unpause;
        _bindProvider.GetBindOfType(BindType.PauseUnpause).PressBindAction -= _uiHandler.CloseControlsMenu;
        _bindProvider.GetBindOfType(BindType.PauseUnpause).PressBindAction -= OnControlsClosed;
    }

    private void OnControlsOpened()
    {
        _bindProvider.GetBindOfType(BindType.PauseUnpause).PressBindAction -= Unpause;
        _bindProvider.GetBindOfType(BindType.PauseUnpause).PressBindAction += _uiHandler.CloseControlsMenu;
        _bindProvider.GetBindOfType(BindType.PauseUnpause).PressBindAction += OnControlsClosed;
    }

    private void Unpause()
    {
        _uiHandler.ClosePauseMenu();
        _bindProvider.GetBindOfType(BindType.PauseUnpause).PressBindAction += Pause;
        _bindProvider.GetBindOfType(BindType.PauseUnpause).PressBindAction -= Unpause;
    }

    private void Pause()
    {
        _uiHandler.OpenPauseMenu();
        _bindProvider.GetBindOfType(BindType.PauseUnpause).PressBindAction -= Pause;
        _bindProvider.GetBindOfType(BindType.PauseUnpause).PressBindAction += Unpause;
    }
}