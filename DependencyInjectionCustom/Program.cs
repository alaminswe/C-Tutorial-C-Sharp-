
// Register Services
var services = new CustomServiceCollection();

services.AddTransient<ITransientService, TransientService>();
services.AddScoped<IScopedService, ScopedService>();
services.AddSingleton<ISingletonService, SingletonService>();

services.AddTransient<NotificationService>();

// Build Root Provider
var provider = services.BuildServiceProvider();

Console.WriteLine("====================================");
Console.WriteLine("TRANSIENT");
Console.WriteLine("====================================");

var transient1 = provider.GetRequiredService<ITransientService>();
var transient2 = provider.GetRequiredService<ITransientService>();

Console.WriteLine($"Transient 1 : {transient1.Id}");
Console.WriteLine($"Transient 2 : {transient2.Id}");
Console.WriteLine($"Same Object : {ReferenceEquals(transient1, transient2)}");

Console.WriteLine();

Console.WriteLine("====================================");
Console.WriteLine("SINGLETON");
Console.WriteLine("====================================");

var singleton1 = provider.GetRequiredService<ISingletonService>();
var singleton2 = provider.GetRequiredService<ISingletonService>();

Console.WriteLine($"Singleton 1 : {singleton1.Id}");
Console.WriteLine($"Singleton 2 : {singleton2.Id}");
Console.WriteLine($"Same Object : {ReferenceEquals(singleton1, singleton2)}");

Console.WriteLine();

Console.WriteLine("====================================");
Console.WriteLine("SCOPED");
Console.WriteLine("====================================");

// ---------- Scope 1 ----------
var scope1 = provider.CreateScope();

var scoped1 = scope1.ServiceProvider.GetRequiredService<IScopedService>();
var scoped2 = scope1.ServiceProvider.GetRequiredService<IScopedService>();

Console.WriteLine("Scope 1");

Console.WriteLine($"Scoped 1 : {scoped1.Id}");
Console.WriteLine($"Scoped 2 : {scoped2.Id}");
Console.WriteLine($"Same Object : {ReferenceEquals(scoped1, scoped2)}");

Console.WriteLine();

// ---------- Scope 2 ----------
var scope2 = provider.CreateScope();

var scoped3 = scope2.ServiceProvider.GetRequiredService<IScopedService>();

Console.WriteLine("Scope 2");

Console.WriteLine($"Scoped 3 : {scoped3.Id}");

Console.WriteLine();
Console.WriteLine($"Scope1 == Scope2 ? {ReferenceEquals(scoped1, scoped3)}");

Console.WriteLine();

Console.WriteLine();
Console.WriteLine("Done...");