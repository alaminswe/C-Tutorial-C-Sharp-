public sealed class CustomServiceCollection
{
    private readonly List<ServiceDescriptor> _services = [];

    //Transient
    public void AddTransient<TService, TImplementation>()  // AddTransient<IEmailService, EmailService>();
    {
        _services.Add(
            new ServiceDescriptor(
                typeof(TService),
                typeof(TImplementation),
                ServiceLifetime.Transient));
    }

    public void AddTransient<TService>()
    {
        _services.Add(
            new ServiceDescriptor(
                typeof(TService),
                typeof(TService),
                ServiceLifetime.Transient));
    }

    //Singleton
    public void AddSingleton<TService, TImplementation>()  // AddTransient<IEmailService, EmailService>();
    {
        _services.Add(
            new ServiceDescriptor(
                typeof(TService),
                typeof(TImplementation),
                ServiceLifetime.Singleton));
    }

    public void AddSingleton<TService>()
    {
        _services.Add(
            new ServiceDescriptor(
                typeof(TService),
                typeof(TService),
                ServiceLifetime.Singleton));
    }

    //Scooped
    public void AddScoped<TService, TImplementation>()
    {
        _services.Add(
            new ServiceDescriptor(
                typeof(TService),
                typeof(TImplementation),
                ServiceLifetime.Scoped));
    }

    public void AddScoped<TService>()
    {
        _services.Add(
            new ServiceDescriptor(
                typeof(TService),
                typeof(TService),
                ServiceLifetime.Scoped));
    }

    

    public ServiceProvider BuildServiceProvider()
    {
        return new ServiceProvider(_services.AsReadOnly());
    }
}