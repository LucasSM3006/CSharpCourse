Rectangle rectangle = new Rectangle(20, 11);
ShapesMeasurementCalculator shapesMeasurementCalculator = new ShapesMeasurementCalculator();

Console.WriteLine($"Rectangle0's width: {rectangle.GetWidth()}");
Console.WriteLine($"Rectrangle0's height: {rectangle.GetHeight()}");

rectangle.SetWidth(10);
rectangle.SetHeight(2);

Console.WriteLine($"Rectangle0's width: {rectangle.GetWidth()}");
Console.WriteLine($"Rectrangle0's height: {rectangle.GetHeight()}");

Rectangle rectangle1 = new Rectangle(70, 22);

Console.WriteLine($"Rectangle1's width: {rectangle.GetWidth()}");
Console.WriteLine($"Rectangle1's height: {rectangle.GetHeight()}");

rectangle1.SetWidth(33);
rectangle1.SetHeight(222);

Console.WriteLine($"Rectangle1's width: {rectangle.GetWidth()}");
Console.WriteLine($"Rectangle1's height: {rectangle.GetHeight()}");

Console.WriteLine($"Rectangle0's area: {shapesMeasurementCalculator.CalculateArea(rectangle)}");
Console.WriteLine($"Rectangle1's area: {shapesMeasurementCalculator.CalculateArea(rectangle1)}");

Console.WriteLine($"Rectangle0's circumference: {shapesMeasurementCalculator.CalculateCircumference(rectangle)}");
Console.WriteLine($"Rectangle1's circumference: {shapesMeasurementCalculator.CalculateCircumference(rectangle1)}");

// Manipulating via the Property, note how the variables are private. No different to a getter and setter tbh, both of them work the same.

// If the setter was private, you could modify it like this:
// rectangle.SideA = 10;

// Accessing getters via property:
Console.WriteLine(rectangle.Height);

Console.ReadKey();

public class Rectangle
{
    public Rectangle(int width, int height)
    {
        Width = GetLengthOrDefault(width, nameof(Width));
        Height = GetLengthOrDefault(height, nameof(Height));
    }

    // Property
    // Properties allow you to manipulate them as if they were public variables.

    // This is known as 'backing field'. See how we have an invisible variable in the constructor? It's declared down here, and the compiler takes that into account.
    public int Width { get; private set; }
    public int Height { get; private set; }

    // This is how you do it if you have some logic to perform on the getters and setters.

    //public int Height
    //{
    //    get
    //    {
    //        return Height;
    //    }
    //    set
    //    {
    //        Height = GetLengthOrDefault(value, "Height");
    //    }
    //}

    // *-------------------------------*

    // There's also this way if you want to use expression body methods
    
    //private int _width;
    //public int width {
    //    get => _width;
    //    set => _width = value;
    //}

    // So, what's the difference between fields and properties?
    // 1. Fields are like variable, or variable-like, while properties are method-like.
    // 2. Fields have a single access for modifiers, while properties have separate access modifiers for getters and setters. For the record, 'fields' are APPARENTLY variables. Parameter variables are fields.
    // 3. Fields have no separate getter and setters, while properties can have either the getter or the setter removed.
    // 4. Fields cannot be overriden in derived classes (inheritance), while properties can.
    // 5. Fields should always be private, properties can safely be public.


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
}

public class ShapesMeasurementCalculator
{
    public int CalculateCircumference(Rectangle rectangle) => 2 * rectangle.SideA + 2 * rectangle.SideB;

    public int CalculateArea(Rectangle rectangle) => rectangle.SideA * rectangle.SideB;
}

// Encapsulation: Bundling data with methods that operate on it in the same class.
// Data hiding: Making fields private instead of public.