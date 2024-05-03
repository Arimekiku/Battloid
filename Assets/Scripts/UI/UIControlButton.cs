using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIControlButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI controlName;
    [SerializeField] private Button controlBind;
    [SerializeField] private TextMeshProUGUI controlBindName;

    public event Action<UIControlButton> OnButtonClicked;
    public KeysAction BindAction { get; private set; }

    public void Init(KeysAction bindAction, KeyCode bindKey)
    {
        controlName.text = bindAction.ToString();
        controlBindName.text = bindKey.ToString();

        BindAction = bindAction;

        controlBind.onClick.AddListener(OnBindButtonClicked);
    }

    public void ChangeBindKey(KeyCode newKey)
    {
        controlBindName.text = newKey.ToString();
    }
    
    private void OnBindButtonClicked()
    {
        OnButtonClicked?.Invoke(this);
    }
}