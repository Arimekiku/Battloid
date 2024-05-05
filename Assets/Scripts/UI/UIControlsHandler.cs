using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public class UIControlsHandler : MonoBehaviour
{
    private UIControlButton _selectedButton;
    private BindHandler _bindHandler;

    private KeyCode _lastKeyPressed;
    private KeyCode[] _keyCodes;
    
    public void Init(BindProvider bindProvider, BindHandler bindHandler, ButtonsFactory buttonsFactory)
    {
        _keyCodes = Enum.GetValues(typeof(KeyCode))
            .Cast<KeyCode>().Where(k => k < KeyCode.Mouse0).ToArray();
        
        _bindHandler = bindHandler;
        
        var binds = bindProvider.GetBinds();

        foreach (var bind in binds)
        {
            var button = buttonsFactory.InstantiateControlButton(bind);
            button.OnButtonClicked += SelectControlButton;
        }
    }

    private void SelectControlButton(UIControlButton selectedButton)
    {
        _selectedButton = selectedButton;

        StartCoroutine(ChangeBindSequence());
    }

    private IEnumerator ChangeBindSequence()
    {
        yield return WaitForAnyKeyPress();
        
        _bindHandler.ChangeBindKey(_selectedButton.ConnectedBindType, _lastKeyPressed);
        
        _lastKeyPressed = KeyCode.None;
        _selectedButton = null;
    }
    
    private IEnumerator WaitForAnyKeyPress()
    {
        while(true)
        {
            if (Input.anyKeyDown)
            {
                foreach (var key in _keyCodes)
                {
                    if (!Input.GetKeyDown(key)) 
                        continue;
                    
                    _lastKeyPressed = key;
                }

                yield break;
            }
            
            yield return null;
        }
    }
}