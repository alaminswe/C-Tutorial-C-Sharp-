public sealed class ServiceScope
{
    public ServiceProvider ServiceProvider { get; }

    public ServiceScope(ServiceProvider provider)
    {
        ServiceProvider = provider;
    }
}