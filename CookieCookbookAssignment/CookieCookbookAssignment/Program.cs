string formatToSave ;


Console.WriteLine("Select the type of format you'd prefer to store. (json or txt)");
string userInput = Console.ReadLine();

if(userInput.ToLower() == "json")
{
    formatToSave = "json";
}
else if (userInput.ToLower() == "txt")
{
    formatToSave = "txt";
}
else
{
    Console.WriteLine("Invalid input! Please enter either 'txt' or 'json'!");
}

public class MainFlow
{

    public void RunProgram()
    {

        if (RecipeFile.Exists) ;
        Console.WriteLine();
    }
}

public abstract class Ingredient
{
    public int Id { get; }

    public Ingredient(int id)
    {
        Id = id;
    }

    public abstract string Instructions();
}

public class Recipe
{
    List<Ingredient> ingredients;
}

public class RecipePrinter
{
    void PrintRecipes()
    {
        Console.WriteLine();
    }
}

public class StoreRecipes
{
    const string FileName = "recipes";
    const FileFormat fileFormat = FileFormat.Json; // Change this to change how it stores.
}

public interface StringTextualRepository
{
    public void Save(string text);
}

public class StringSaverJson : StringTextualRepository
{

}

public class StringSaverTxt : StringTextualRepository
{

}

public class Flour : Ingredient
{

    public FlourType FlourType;

    public Flour(int id, FlourType flourType) : base(id)
    {
        FlourType = flourType;
    }

    public override string Instructions()
    {
        return "Sieve. Add to other ingredients.";
    }
}

public class Butter : Ingredient
{
    public Butter(int id) : base(id)
    {
    }

    public override string Instructions()
    {
        return "Melt on low heat. Add to other ingredients.";
    }
}

public class Chocolate : Ingredient
{
    public Chocolate(int id) : base(id)
    {
    }

    public override string Instructions()
    {
        return "Melt in a water bath. Add to other ingredients.";
    }
}

public class Sugar : Ingredient
{
    public Sugar(int id) : base(id)
    {
    }

    public override string Instructions()
    {
        return "Add to other ingredients.";
    }
}

public class Cardamom : Ingredient
{
    public Cardamom(int id) : base(id)
    {
    }

    public override string Instructions()
    {
        return "Take half a teaspoon. Add to other ingredients.";
    }
}

public class Cinnamon : Ingredient
{
    public Cinnamon(int id) : base(id)
    {
    }

    public override string Instructions()
    {
        return "Take half a teaspoon. Add to other ingredients.";
    }
}

public class CocoaPowder : Ingredient
{
    public CocoaPowder(int id) : base(id)
    {
    }

    public override string Instructions()
    {
        return "Add to other ingredients.";
    }
}

public enum FlourType
{
    Wheat,
    Coconut
}

public enum FileFormat
{
    Json,
    Txt
}