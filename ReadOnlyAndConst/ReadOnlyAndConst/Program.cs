Rectangle rectangle = new Rectangle(20, 11);
ShapesMeasurementCalculator shapesMeasurementCalculator = new ShapesMeasurementCalculator();

Console.WriteLine($"Rectangle0's width: {rectangle.getSideA()}");
Console.WriteLine($"Rectrangle0's height: {rectangle.getSideB()}");

//rectangle.setSideA(10);
//rectangle.setSideB(2);

Console.WriteLine($"Rectangle0's width: {rectangle.getSideA()}");
Console.WriteLine($"Rectrangle0's height: {rectangle.getSideB()}");

Rectangle rectangle1 = new Rectangle(70, 22);

Console.WriteLine($"Rectangle1's width: {rectangle1.getSideA()}");
Console.WriteLine($"Rectrangle1's height: {rectangle1.getSideB()}");

//rectangle1.setSideA(33);
//rectangle1.setSideB(222);

Console.WriteLine($"Rectangle1's width: {rectangle1.getSideA()}");
Console.WriteLine($"Rectrangle1's height: {rectangle1.getSideB()}");

Console.WriteLine($"Rectangle0's area: {shapesMeasurementCalculator.calculateArea(rectangle)}");
Console.WriteLine($"Rectangle1's area: {shapesMeasurementCalculator.calculateArea(rectangle1)}");

Console.WriteLine($"Rectangle0's circumference: {shapesMeasurementCalculator.calculateCircumference(rectangle)}");
Console.WriteLine($"Rectangle1's circumference: {shapesMeasurementCalculator.calculateCircumference(rectangle1)}");

Console.ReadKey();

public class Rectangle
{
    const int NUMBER_OF_SIDES = 4; // Value must also be known during compile time. So you could even assign it "2 + 2", but assigning it "GetConstValue()" would not work due to that being executed during runtime.
    readonly int NumberOfSidesReadOnly;
    private readonly int _sideA;
    private readonly int _sideB;

    public Rectangle(int width, int height)
    {
        NumberOfSidesReadOnly = 4;
        _sideA = getLengthOrDefault(width, nameof(_sideA));
        _sideB = getLengthOrDefault(height, nameof(height));
    }

    // Setters have to be removed, as readonly will only allow these values to be immutable. They cannot be modified.
    // The difference between readonly values and const being the fact that you have to declare values to a const right away. Const NEEDS to have values attributed to it before compile time.

    //public void setSideA(int width)
    //{
    //    this._sideA = width;
    //}

    //public void setSideB(int height)
    //{
    //    this._sideB = height;
    //}

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
        const int defaultValueIfNotPositive = 0;
        //const var defaultValueIfNotPositive = 0; The 'var' type doesn't work due to it being a constant. Even if the value is assigned, it won't compile.
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
    public int calculateCircumference(Rectangle rectangle) => 2 * rectangle.getSideA() + 2 * rectangle.getSideB();

    public int calculateArea(Rectangle rectangle) => rectangle.getSideA() * rectangle.getSideB();
}

// Encapsulation: Bundling data with methods that operate on it in the same class.
// Data hiding: Making fields private instead of public.