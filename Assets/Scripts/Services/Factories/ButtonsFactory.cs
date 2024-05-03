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

    public UIControlButton InstantiateControlButton(KeysAction withAction, KeyCode withKey)
    {
        var buttonInstance = Object.Instantiate(_controlButtonPrefab, _container);
        buttonInstance.Init(withAction, withKey);

        return buttonInstance;
    }
}