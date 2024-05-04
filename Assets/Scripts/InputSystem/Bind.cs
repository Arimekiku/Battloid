using System;
using UnityEngine;

public class Bind
{
    public event Action PressBindAction;
    public event Action ContinuousBindAction;
    public event Action ReleaseBindAction;
    public event Action ChangeBindAction;
    
    public readonly string BindName;
    private readonly BindType _bindType;
    private KeyCode _bindKey;

    public Bind(BindConfig bindConfig)
    {
        _bindKey = bindConfig.BindKey;

        _bindType = bindConfig.BindType;

        BindName = bindConfig.BindName;
    }

    public KeyCode GetBindKey()
    {
        return _bindKey;
    }
    
    public void ChangeBindKey(KeyCode newKeyCode)
    {
        _bindKey = newKeyCode;
        
        ChangeBindAction?.Invoke();
    }

    public BindType GetBindType()
    {
        return _bindType;
    }
    
    public void CheckJustPressed()
    {
        if (Input.GetKeyDown(_bindKey))
            PressBindAction?.Invoke();
    }

    public void CheckPressed()
    {
        if (Input.GetKey(_bindKey))
            ContinuousBindAction?.Invoke();
    }

    public void CheckJustReleased()
    {
        if (Input.GetKeyUp(_bindKey))
            ReleaseBindAction?.Invoke();
    }
}