using UnityEngine;

public class GameEntry : MonoBehaviour
{
    [SerializeField] private MainHeroBehaviour mainHero;
    [SerializeField] private GameUpdater updater;
    [SerializeField] private UIHandler interfaceHandler;
    [SerializeField] private UIControlsHandler controlsHandler;
    [SerializeField] private UIControlButton controlButtonPrefab;
    [SerializeField] private Transform controlButtonsContainer;

    private BindProvider _bindProvider;
    private BindHandler _bindHandler;
    private ButtonsFactory _buttonsFactory;
    private UIBindSubscriber _uiBindSubscriber;
    
    private void Awake()
    {
        InitBindInputs();
        InitFactories();
        InitUI();
    }

    private void InitBindInputs()
    {
        _bindProvider = new BindProvider();
        _bindHandler = new BindHandler(_bindProvider);
        
        updater.AddUpdatable(_bindHandler);
    }

    private void InitFactories()
    {
        _buttonsFactory = new ButtonsFactory(controlButtonPrefab, controlButtonsContainer);
    }

    private void InitUI()
    {
        _uiBindSubscriber = new UIBindSubscriber(_bindProvider, interfaceHandler);
        controlsHandler.Init(_bindProvider, _bindHandler, _buttonsFactory);
    }
}
