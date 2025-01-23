Rectangle rectangle = new Rectangle(20, 11);
ShapesMeasurementCalculator shapesMeasurementCalculator = new ShapesMeasurementCalculator();

Console.WriteLine($"Rectangle0's width: {rectangle.getWidth()}");
Console.WriteLine($"Rectrangle0's height: {rectangle.getHeight()}");

rectangle.setWidth(10);
rectangle.setHeight(2);

Console.WriteLine($"Rectangle0's width: {rectangle.getWidth()}");
Console.WriteLine($"Rectrangle0's height: {rectangle.getHeight()}");

Rectangle rectangle1 = new Rectangle(70, 22);

Console.WriteLine($"Rectangle1's width: {rectangle1.getWidth()}");
Console.WriteLine($"Rectrangle1's height: {rectangle1.getHeight()}");

rectangle1.setWidth(33);
rectangle1.setHeight(222);

Console.WriteLine($"Rectangle1's width: {rectangle1.getWidth()}");
Console.WriteLine($"Rectrangle1's height: {rectangle1.getHeight()}");

Console.WriteLine($"Rectangle0's area: {shapesMeasurementCalculator.calculateArea(rectangle)}");
Console.WriteLine($"Rectangle1's area: {shapesMeasurementCalculator.calculateArea(rectangle1)}");

Console.WriteLine($"Rectangle0's circumference: {shapesMeasurementCalculator.calculateCircumference(rectangle)}");
Console.WriteLine($"Rectangle1's circumference: {shapesMeasurementCalculator.calculateCircumference(rectangle1)}");

Console.ReadKey();

public class Rectangle
{
    private int _sideA; // Values are initialized as zero.
    private int _sideB; // Bit of a weird design choice if I'm honest, I feel like it should be null, but alright.

    public Rectangle(int width, int height)
    {
        _sideA = getLengthOrDefault(width, nameof(_sideA));
        _sideB = getLengthOrDefault(height, nameof(height));
    }

    public void setSideA(int width)
    {
        this._sideA = width;
    }

    public void setSideB(int height)
    {
        this._sideB = height;
    }

    public int getSideA()
    {
        return _sideA;
    }

    public int getSideB()
    {
        return _sideB;
    }

    private int getLengthOrDefault(int length, string name)
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
    public int calculateCircumference(Rectangle rectangle) => 2 * rectangle.getWidth() + 2 * rectangle.getHeight();

    public int calculateArea(Rectangle rectangle) => rectangle.getWidth() * rectangle.getHeight();
}

// Encapsulation: Bundling data with methods that operate on it in the same class.
// Data hiding: Making fields private instead of public.