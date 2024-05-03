using UnityEngine;

public class GameEntry : MonoBehaviour
{
    [SerializeField] private MainHeroBehaviour mainHero;
    [SerializeField] private GameUpdater updater;
    [SerializeField] private UIHandler interfaceHandler;
    [SerializeField] private UIControlSettings controlSettings;
    [SerializeField] private UIControlButton controlButtonPrefab;
    [SerializeField] private Transform controlButtonsContainer;

    private ActionMap _actionMap;
    private ButtonsFactory _buttonsFactory;
    
    private void Awake()
    {
        InitActionMap();
        InitFactories();
        InitInputSystem();
        InitUI();
    }

    private void InitActionMap()
    {
        _actionMap = new ActionMap();
    }

    private void InitFactories()
    {
        _buttonsFactory = new ButtonsFactory(controlButtonPrefab, controlButtonsContainer);
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

    private void InitUI()
    {
        controlSettings.Init(_actionMap, _buttonsFactory);
    }
}
