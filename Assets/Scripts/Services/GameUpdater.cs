using System.Collections.Generic;
using UnityEngine;

public class GameUpdater : MonoBehaviour
{
    private readonly List<IUpdatable> _updatables = new();

    private void Update()
    {
        foreach (var updatable in _updatables)
            updatable.Update();
    }

    public void AddUpdatable(IUpdatable entity)
    {
        _updatables.Add(entity);
    }
}