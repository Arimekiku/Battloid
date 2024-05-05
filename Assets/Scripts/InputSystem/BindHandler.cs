using System.Collections.Generic;
using UnityEngine;

public class BindHandler : IUpdatable
{
    private readonly List<Bind> _defaultBinds;
    private readonly BindProvider _bindProvider;

    public BindHandler(BindProvider bindProvider)
    {
        _bindProvider = bindProvider;

        _defaultBinds = new List<Bind>(_bindProvider.GetBinds());
    }
    
    public void Update()
    {
        foreach (var bind in _bindProvider.GetBinds())
        {
            bind.CheckJustPressed();
            bind.CheckPressed();
            bind.CheckJustReleased();
        }
    }

    public void ChangeBindKey(BindType bindType, KeyCode newKey)
    {
        var bind = _bindProvider.GetBindWithKey(newKey);
        bind?.ChangeBindKey(KeyCode.None);

        bind = _bindProvider.GetBindOfType(bindType);
        bind.ChangeBindKey(newKey);
    }

    public void ResetToDefaults()
    {
        foreach (var t in _defaultBinds)
        {
            var bind = _bindProvider.GetBindOfType(t.GetBindType());
            bind.ChangeBindKey(t.GetBindKey());
        }
    }
}