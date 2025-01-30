
public abstract class Dessert
{

}

public abstract class Bakeable
{
    public abstract string GetInstructions();
}

public class Cookies : Dessert
{

}

public class Pizza : Bakeable
{
    public override string GetInstructions()
    {
        throw new NotImplementedException();
    }
}