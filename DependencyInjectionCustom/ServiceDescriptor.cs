public enum ServiceLifetime
{
    Transient,
    Scoped,
    Singleton,
}

public class ServiceDescriptor(
    Type serviceType,
    Type implementationType, 
    ServiceLifetime lifetime)
{
    public Type ServiceType{ get; } = serviceType;
    public Type ImplementationType{ get; } = implementationType;
    public ServiceLifetime Lifetime{ get; } = lifetime;
}