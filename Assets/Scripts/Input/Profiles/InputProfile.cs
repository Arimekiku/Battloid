public abstract class InputProfile : IUpdatable
{
    protected readonly ActionMap Map;
    protected readonly IInputProfileChanger ProfileChanger;

    protected InputProfile(ActionMap map, IInputProfileChanger profileChanger)
    {
        Map = map;
        ProfileChanger = profileChanger;
    }
    
    public abstract void Update();
}