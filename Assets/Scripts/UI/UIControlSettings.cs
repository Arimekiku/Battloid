using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public class UIControlSettings : MonoBehaviour
{
    private UIControlButton _selectedButton;
    private ActionMap _actionMap;

    private KeyCode _lastKeyPressed;
    private KeyCode[] _keyCodes;
    
    public void Init(ActionMap actionMap, ButtonsFactory buttonsFactory)
    {
        _keyCodes = Enum.GetValues(typeof(KeyCode))
            .Cast<KeyCode>().Where(k => k < KeyCode.Mouse0).ToArray();
        
        _actionMap = actionMap;
        
        var actions = _actionMap.GetKeys();

        foreach (var action in actions)
        {
            var button = buttonsFactory.InstantiateControlButton(action, _actionMap.GetControl(action));
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
        
        _actionMap.ChangeControl(_selectedButton.BindAction, _lastKeyPressed);
        _selectedButton.ChangeBindKey(_lastKeyPressed);
        
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
                    break;
                }

                yield break;
            }
            
            yield return null;
        }
    }
}