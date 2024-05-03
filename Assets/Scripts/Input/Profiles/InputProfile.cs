public abstract class InputProfile : IUpdatable
{
    protected readonly ActionProvider Provider;

    protected InputProfile(ActionProvider provider)
    {
        Provider = provider;
    }
    
    public abstract void Update();
}