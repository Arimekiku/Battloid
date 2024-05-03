using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject controlsMenu;
    [SerializeField] private Button continueButton;
    [SerializeField] private Button controlsButton;

    public Button ContinueButton => continueButton;
    public Button ControlsButton => controlsButton;
    
    private void Awake()
    {
        ClosePauseMenu();
        CloseControlsMenu();
        
        continueButton.onClick.AddListener(ClosePauseMenu);
        controlsButton.onClick.AddListener(OpenControlsMenu);
    }

    public void OpenPauseMenu()
    {
        pauseMenu.SetActive(true);
    }

    public void ClosePauseMenu()
    {
        pauseMenu.SetActive(false);
    }

    private void OpenControlsMenu()
    {
        controlsMenu.SetActive(true);

        continueButton.enabled = false;
        controlsButton.enabled = false;
    }

    public void CloseControlsMenu()
    {
        controlsMenu.SetActive(false);
        
        continueButton.enabled = true;
        controlsButton.enabled = true;
    }
}