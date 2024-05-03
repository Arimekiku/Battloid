using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject controlsMenu;

    private Dictionary<KeysAction, Button> _controlsButtons;

    private event Action OnPauseMenuOpened;
    private event Action OnPauseMenuClosed;

    private void Awake()
    {
        ClosePauseMenu();
    }

    public void OpenPauseMenu()
    {
        pauseMenu.SetActive(true);
        
        OnPauseMenuOpened?.Invoke();
    }

    public void ClosePauseMenu()
    {
        pauseMenu.SetActive(false);
        
        OnPauseMenuClosed?.Invoke();
    }

    public void OpenControlsMenu()
    {
        controlsMenu.SetActive(true);
    }

    public void CloseControlsMenu()
    {
        controlsMenu.SetActive(false);
    }
}