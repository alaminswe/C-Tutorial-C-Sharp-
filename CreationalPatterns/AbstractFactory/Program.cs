public interface IButton
{
    void Paint(); 
}

public interface ICheckbox
{
    void Paint(); 
}

public class WinButton : IButton
{
    public void Paint()
    {
        Console.WriteLine("🪟 Painting Windows Button");
    }
}

public class WinCheckbox : ICheckbox
{
    public void Paint()
    {
        Console.WriteLine("🪟 Painting Windows Checkbox");
    }
}

public class MacButton : IButton
{
    public void Paint()
    {
        Console.WriteLine("🍎 Painting Mac Button");
    }
}

public class MacCheckbox : ICheckbox
{
    public void Paint()
    {
        Console.WriteLine("🍎 Painting Mac Checkbox");
    }
}

public interface IGUIFactory
{
    IButton   CreateButton();
    ICheckbox CreateCheckbox();
}

public class WinFactory : IGUIFactory
{
    public IButton   CreateButton()   => new WinButton();
    public ICheckbox CreateCheckbox() => new WinCheckbox();
}

public class MacFactory : IGUIFactory
{
    public IButton   CreateButton()   => new MacButton();
    public ICheckbox CreateCheckbox() => new MacCheckbox();
}

public class Application
{
    private IButton   _button;
    private ICheckbox _checkbox;

    
    public Application(IGUIFactory factory)
    {
        _button   = factory.CreateButton();
        _checkbox = factory.CreateCheckbox();
    }

    public void RenderUI()
    {
        Console.WriteLine("Rendering UI:");
        _button.Paint();
        _checkbox.Paint();
    }
}

// ============================================
// MAIN PROGRAM
// ============================================
class Program
{
    static void Main()
    {
        Console.WriteLine("=== Windows UI ===");

        IGUIFactory factory = new WinFactory();
        IButton btn = factory.CreateButton();
        btn.Paint(); // 🪟 Painting Windows Button

        // Full Application:
        Application winApp = new Application(new WinFactory());
        winApp.RenderUI();

        Console.WriteLine("\n=== Mac UI ===");
        Application macApp = new Application(new MacFactory());
        macApp.RenderUI();
    }
}