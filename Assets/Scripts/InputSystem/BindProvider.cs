using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BindProvider
{
    private const string DefaultBindsPath = "Input";
    
    private readonly List<Bind> _binds;
    
    public BindProvider()
    {
        var keyBinds = Resources.LoadAll<BindConfig>(DefaultBindsPath);

        if (keyBinds.Length == 0)
            throw new Exception("Binds does not found");

        _binds = new List<Bind>();
        foreach (var bindConfig in keyBinds)
        {
            var newBind = new Bind(bindConfig);
            _binds.Add(newBind);
        }
    }
    
    public Bind GetBindOfType(BindType bindType)
    {
        return _binds.First(b => b.GetBindType() == bindType);
    }

    public Bind GetBindWithKey(KeyCode keyCode)
    {
        return _binds.FirstOrDefault(b => b.GetBindKey() == keyCode);
    }

    public Bind[] GetBinds()
    {
        return _binds.ToArray();
    }
}