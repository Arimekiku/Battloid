using UnityEngine;

public class GameEntry : MonoBehaviour
{
    [SerializeField] private MainHeroBehaviour mainHero;
    [SerializeField] private GameUpdater updater;
    [SerializeField] private UIHandler interfaceHandler;

    private ActionMap _actionMap;
    
    private void Awake()
    {
        InitActionMap();
        InitInputSystem();
    }

    private void InitActionMap()
    {
        _actionMap = new ActionMap();
    }

    private void InitInputSystem()
    {
        var inputProfiler = new InputProfiler();

        var gameplayProfile = new UnpauseProfile(mainHero, interfaceHandler, _actionMap, inputProfiler);
        inputProfiler.AddProfile(ProfileType.UnpauseInputProfile, gameplayProfile);

        var pauseProfile = new PauseProfile(interfaceHandler, _actionMap, inputProfiler);
        inputProfiler.AddProfile(ProfileType.PauseInputProfile, pauseProfile);
        
        inputProfiler.ChangeProfile(ProfileType.UnpauseInputProfile);
        updater.AddUpdatable(inputProfiler);
    }
}
