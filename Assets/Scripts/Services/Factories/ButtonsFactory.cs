using UnityEngine;

public class ButtonsFactory
{
    private readonly UIControlButton _controlButtonPrefab;
    private readonly Transform _container;
    
    public ButtonsFactory(UIControlButton controlButtonPrefab, Transform container)
    {
        _controlButtonPrefab = controlButtonPrefab;
        _container = container;
    }

    public UIControlButton InstantiateControlButton(Bind bind)
    {
        var buttonInstance = Object.Instantiate(_controlButtonPrefab, _container);
        buttonInstance.Init(bind);

        return buttonInstance;
    }
}