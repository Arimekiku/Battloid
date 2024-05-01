using System;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

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
}