using UnityEngine;

[CreateAssetMenu(fileName = "Bind Config", menuName = "SO/Bind Config")]
public class BindConfig : ScriptableObject
{
    [SerializeField] private BindType bindType;
    [SerializeField] private string bindName = "Bind Name";
    [SerializeField] private KeyCode bindKey;
    
    public BindType BindType => bindType;
    public KeyCode BindKey => bindKey;
    public string BindName => bindName;
}