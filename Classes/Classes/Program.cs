Rectangle rectangle = new Rectangle(20, 11);

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

Console.ReadKey();

class Rectangle
{
    private int _width; // Values are initialized as zero.
    private int _height; // Bit of a weird design choice if I'm honest, I feel like it should be null, but alright.

    public Rectangle(int width, int height)
    {
        _width = width;
        _height = height;
    }

    public void setWidth(int width)
    {
        this._width = width;
    }

    public void setHeight(int height)
    {
        this._height = height;
    }

    public int getWidth()
    {
        return _width;
    }

    public int getHeight()
    {
        return _height;
    }
}