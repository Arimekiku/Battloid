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
    public BindType ConnectedBindType { get; private set; }

    public void Init(Bind bind)
    {
        bind.ChangeBindAction += () => { ChangeBindKey(bind.GetBindKey()); };
        
        controlName.text = bind.BindName;
        controlBindName.text = bind.GetBindKey().ToString();
        ConnectedBindType = bind.GetBindType();

        controlBind.onClick.AddListener(OnBindButtonClicked);
    }

    private void ChangeBindKey(KeyCode newKey)
    {
        controlBindName.text = newKey.ToString();
    }
    
    private void OnBindButtonClicked()
    {
        OnButtonClicked?.Invoke(this);
    }
}