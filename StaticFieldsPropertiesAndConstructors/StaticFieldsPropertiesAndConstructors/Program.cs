Rectangle rectangle = new Rectangle(20, 11);

Console.WriteLine($"Rectangle0's width: {rectangle.GetWidth()}");
Console.WriteLine($"Rectrangle0's height: {rectangle.GetHeight()}");

rectangle.SetWidth(10);
rectangle.SetHeight(2);

Console.WriteLine($"Rectangle0's width: {rectangle.GetWidth()}");
Console.WriteLine($"Rectrangle0's height: {rectangle.GetHeight()}");

Console.WriteLine($"How many rectangles currently exist: {Rectangle.CountOfInstances}");

Rectangle rectangle1 = new Rectangle(70, 22);

Console.WriteLine($"Rectangle1's width: {rectangle.GetWidth()}");
Console.WriteLine($"Rectangle1's height: {rectangle.GetHeight()}");

rectangle1.SetWidth(33);
rectangle1.SetHeight(222);

Console.WriteLine($"Rectangle1's width: {rectangle.GetWidth()}");
Console.WriteLine($"Rectangle1's height: {rectangle.GetHeight()}");

Console.WriteLine($"Rectangle0's area: {rectangle.CalculateArea()}");
Console.WriteLine($"Rectangle1's area: {rectangle.CalculateArea()}");

Console.WriteLine($"Rectangle0's circumference: {rectangle.CalculateCircumference()}");
Console.WriteLine($"Rectangle1's circumference: {rectangle.CalculateCircumference()}");

Console.WriteLine($"How many rectangles currently exist: {Rectangle.CountOfInstances}");
// Manipulating via the Property, note how the variables are private. No different to a getter and setter tbh, both of them work the same.
// If the setter was private, you could modify it like this:
// rectangle.SideA = 10;
// Accessing getters via property:
Console.WriteLine(rectangle.Height);

// Calculator calculator = new Calculator(); // Reduntant, as calculator will never have different variables. It's stateless.
// And remember, following OOP, static classes cannot be instantiated. 
// Static classes cannot hold non-static methods, but non-static classes can hold static methods.

// Static method call from Rectangle, a non-static class:
Console.WriteLine(Rectangle.DescribeGenerally());

// Static methods cannot be called from instances, btw.
// Console.WriteLine(rectangle1.DescribeGenerally()); // This is a compilation error, it won't work.

Calculator.Add(rectangle1.Width, rectangle1.Height);

// Summoning static variables...

Console.WriteLine($"Number of angles in a Rectangle: {Rectangle.N_OF_ANGLES}");
Console.WriteLine($"Number of sides in a Rectangle: {Rectangle.N_OF_SIDES}");

Console.ReadKey();

public static class Calculator
{
    public static int Add(int x, int y) => x + y;
    public static int Subtract(int x, int y) => x - y;
    public static int Multiply(int x, int y) => x * y;
}

public class Rectangle
{
    // Tested above.
    public static int CountOfInstances { get; private set; }
    // private static DateTime _firstUsed;

    //static Rectangle()
    //{
    //    _firstUsed = DateTime.Now;
    //}

    public Rectangle(int width, int height)
    {
        Width = GetLengthOrDefault(width, nameof(Width));
        Height = GetLengthOrDefault(height, nameof(Height));
        ++CountOfInstances;
    }

    public int Width { get; private set; }
    
    public int Height { get; private set; }

    public void SetWidth(int width)
    {
        Width = GetLengthOrDefault(width, nameof(width));
    }

    public void SetHeight(int height)
    {
        Height = GetLengthOrDefault(height, nameof(height));
    }

    public int GetWidth() => Width;

    public int GetHeight() => Height;

    private int GetLengthOrDefault(int length, string name)
    {
        int defaultValueIfNotPositive = 0;
        if (length <= 0)
        {
            Console.WriteLine($"{name} must be a positive number.");
            return defaultValueIfNotPositive;
        }
        return length;
    }
    // These are methods or functions.
    public int CalculateCircumference() => 2 * Width + 2 * Height;
    public int CalculateArea() => Width * Height;
    // This is a property, it holds data.
    public string Description => $"A rectangle with width {Width} and height {Height}";

    // While non static variables cannot be used in static methods, constants can totally be used. Constants are also static btw, just not implied.
    public const int N_OF_SIDES = 4;
    public const int N_OF_ANGLES = 4;
    public static string DescribeGenerally() => $"A plane with {N_OF_SIDES} straight sides and {N_OF_ANGLES} right angles.";
}