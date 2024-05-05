using System.Collections.Generic;
using UnityEngine;

public class BindHandler : IUpdatable
{
    private readonly Dictionary<BindType, KeyCode> _defaultBinds;
    private readonly BindProvider _bindProvider;

    public BindHandler(BindProvider bindProvider)
    {
        _bindProvider = bindProvider;

        _defaultBinds = new Dictionary<BindType, KeyCode>();
        foreach (var b in _bindProvider.GetBinds())
            _defaultBinds.Add(b.GetBindType(), b.GetBindKey());
    }
    
    public void Update()
    {
        foreach (var bind in _bindProvider.GetBinds())
        {
            bind.CheckJustPressed();
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
            var bind = _bindProvider.GetBindOfType(t.Key);
            bind.ChangeBindKey(t.Value);
        }
    }
}