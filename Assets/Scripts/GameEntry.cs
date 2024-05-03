using UnityEngine;
using UnityEngine.Serialization;

public class GameEntry : MonoBehaviour
{
    [SerializeField] private MainHeroBehaviour mainHero;
    [SerializeField] private GameUpdater updater;
    [SerializeField] private UIHandler interfaceHandler;
    [SerializeField] private UIControlsHandler controlsHandler;
    [SerializeField] private UIControlButton controlButtonPrefab;
    [SerializeField] private Transform controlButtonsContainer;

    private ActionProvider _actionProvider;
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
        _actionProvider = new ActionProvider();
    }

    private void InitFactories()
    {
        _buttonsFactory = new ButtonsFactory(controlButtonPrefab, controlButtonsContainer);
    }

    private void InitInputSystem()
    {
        var inputProfiler = new InputProfiler(interfaceHandler, mainHero);
        updater.AddUpdatable(inputProfiler);
    }

    private void InitUI()
    {
        controlsHandler.Init(_actionProvider, _buttonsFactory);
    }
}
