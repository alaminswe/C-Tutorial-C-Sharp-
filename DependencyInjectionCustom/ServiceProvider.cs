using System.Dynamic;

public class ServiceProvider
{
    private readonly IReadOnlyList<ServiceDescriptor> _serviceDescriptors;

    private readonly Dictionary<Type, object> _singletonInstances = [];

    private readonly Dictionary<Type, object> _scopedInstances = [];
    public ServiceProvider(IReadOnlyList<ServiceDescriptor> serviceDescriptors)
    {
        _serviceDescriptors = serviceDescriptors;
        _singletonInstances = [];
        _scopedInstances = [];
    }

    private ServiceProvider(IReadOnlyList<ServiceDescriptor> descriptors, Dictionary<Type, object> singletonInstances)
    {
        _serviceDescriptors = descriptors;

        // Singleton
        _singletonInstances = singletonInstances;

        // Scope-each-Dictionary
        _scopedInstances = [];
    }
    public ServiceScope CreateScope()
    {
        return new ServiceScope(
            new ServiceProvider(
                _serviceDescriptors,
                _singletonInstances));
    }
    public T GetRequiredService<T>()
    {
        return (T)GetService(typeof(T));
    }
    public object GetService(Type serviceType)
    {
        var descriptor = _serviceDescriptors.FirstOrDefault(x => x.ServiceType == serviceType) ?? throw new Exception($"Service Type {serviceType.Name} Not Registered");

        return descriptor.Lifetime switch
        {
            ServiceLifetime.Transient =>
                CreateInstance(descriptor.ImplementationType),

            ServiceLifetime.Singleton =>
                GetSingleton(descriptor),

            ServiceLifetime.Scoped =>
                GetScoped(descriptor),

            _ => throw new NotImplementedException()
        };
    }
    private object GetScoped(ServiceDescriptor descriptor)
    {
        if (_scopedInstances.TryGetValue(
                descriptor.ServiceType,
                out var instance))
        {
            return instance;
        }

        instance = CreateInstance(descriptor.ImplementationType);

        _scopedInstances[descriptor.ServiceType] = instance;

        return instance;
    }

    private object GetSingleton(ServiceDescriptor descriptor)
    {
        if (_singletonInstances.TryGetValue(descriptor.ServiceType, out var instance))
        {
            return instance;
        }

        instance = CreateInstance(descriptor.ImplementationType);

        _singletonInstances[descriptor.ServiceType] = instance;

        return instance;
    }
    public object CreateInstance(Type implementType)
    {
        var ctor = implementType.GetConstructors();
        var firsConstructor = ctor.FirstOrDefault()
            ?? throw new Exception($"No Public Constructor Found {implementType.Name}");
        var perameters = firsConstructor.GetParameters().ToArray();

        if (perameters.Length == 0)
        {
            return Activator.CreateInstance(implementType);
        }

        var perameterImplementations = new Object[perameters.Length];
        for (int i = 0; i < perameters.Length; i++)
        {
            perameterImplementations[i] = GetService(perameters[i].ParameterType);
        }
        return Activator.CreateInstance(implementType, perameterImplementations);

    }
}