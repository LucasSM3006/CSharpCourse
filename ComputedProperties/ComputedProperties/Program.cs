﻿Rectangle rectangle = new Rectangle(20, 11);

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

Console.WriteLine($"Rectangle0's area: {rectangle.CalculateArea()}");
Console.WriteLine($"Rectangle1's area: {rectangle.CalculateArea()}");

Console.WriteLine($"Rectangle0's circumference: {rectangle.CalculateCircumference()}");
Console.WriteLine($"Rectangle1's circumference: {rectangle.CalculateCircumference()}");

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
}