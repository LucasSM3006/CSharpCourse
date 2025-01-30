/*
 * Abstract methods - Shapes

The purpose of the exercise is to make the GetShapesAreas method work.

public static class ExerciseShapes
    {
        public static List<double> GetShapesAreas(List<Shape> shapes)
        {
            var result = new List<double>();
            
            foreach(var shape in shapes)
            {
                result.Add(shape.CalculateArea());
            }
            
            return result;
        }
    }

This method takes a collection of Shapes, and returns a collection of their areas as doubles.


A Shape's area is a double number, so a floating-point numeric type. For example, we can use doubles like this:

double someNumber = 10.05;


Your task is to:

    Add the abstract Shape class in such a way that it can be used in the GetShapesAreas method

    Finish the implementations of the Square, Rectangle, and Circle classes so that each has the CalculateArea method that can be used in GetShapesAreas method


To calculate the area of a circle, we will need the PI number. We can access it using the Math.PI constant. 
 */

List<double> areas = ExerciseShapes.GetShapesAreas(new List<Shape>() { new Square(2), new Rectangle(2, 5), new Circle(5) });

foreach (double area in areas)
{
    Console.WriteLine($"Area: {area}");
}

Console.ReadKey();

public static class ExerciseShapes
{
    public static List<double> GetShapesAreas(List<Shape> shapes)
    {
        var result = new List<double>();

        foreach (var shape in shapes)
        {
            result.Add(shape.CalculateArea());
        }

        return result;
    }
}

//your code goes here - define the Shape class
public abstract class Shape
{
    public abstract double CalculateArea();
}

public class Square : Shape
{
    public double Side { get; }

    public Square(double side)
    {
        Side = side;
    }

    public override double CalculateArea()
    {
        return Side * Side;
    }
}


public class Rectangle : Shape
{
    public double Width { get; }
    public double Height { get; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public override double CalculateArea()
    {
        return Width * Height;
    }
}

public class Circle : Shape
{
    public double Radius { get; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public override double CalculateArea()
    {
        return Math.PI * (Radius * Radius);
    }
}
