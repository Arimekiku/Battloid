using System.Collections.Generic;

public class InputProfiler : IUpdatable, IInputProfileChanger
{
    private readonly Dictionary<ProfileType, InputProfile> _profiles = new();
    private InputProfile _currentProfile;
    
    public void Update()
    {
        _currentProfile?.Update();
    }

    public void AddProfile(ProfileType type, InputProfile profile)
    {
        _profiles.Add(type, profile);
    }
    
    public void ChangeProfile(ProfileType type)
    {
        _currentProfile = _profiles[type];
    }
}