public class MainFlow
{
    private StringTextualRepository repository;

    public void RunProgram()
    {
        Recipe recipe = new Recipe();
        Console.WriteLine("Select the type of format you'd prefer. (json or txt)");
        string userInput;
        bool validInput = false;
        do
        {
            userInput = Console.ReadLine();

            if (userInput.ToLower() == "json")
            {
                repository = new RecipeRepositoryJson();
                validInput = true;
            }
            else if (userInput.ToLower() == "txt")
            {
                repository = new RecipeRepositoryTxt();
                validInput = true;
            }
            else
            {
                Console.WriteLine("Invalid input! Please enter either 'txt' or 'json'!");
                validInput = false;
            }
        } while (validInput == false);

        Console.WriteLine(repository.Load("recipe"));

        Console.WriteLine("Create a new cookie recipe!");

        List<Ingredient> availableIngredients = MakeIngredients();

        PrintIngredients(availableIngredients);

        validInput = true;

        do
        {
            Console.WriteLine("Add an ingredient by is ID or type anything else if finished");

            userInput = Console.ReadLine();

            int id;
            validInput = int.TryParse(userInput, out id);

            foreach (Ingredient ingredient in availableIngredients)
            {
                if (ingredient.Id == id)
                {
                    recipe.Add(ingredient);
                    break;
                }
                Console.WriteLine("No ingredients match that ID, try again.");
            }
        } while (validInput == true);


        if(recipe.isEmpty())
        {
            Console.WriteLine("No ingredients have been selected. The recipe will not be saved.");
        }
        else
        {
            Console.WriteLine("Recipe added: ");

            Console.WriteLine(recipe.BuildRecipe());

            repository.Save(recipe.GetIds());
        }

        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }

    private List<Ingredient> MakeIngredients()
    {
        return new List<Ingredient>()
        {
            new WheatFlour(),
            new CoconutFlour(),
            new Butter(),
            new Chocolate(),
            new Sugar(),
            new Cardamom(),
            new Cinnamon(),
            new CocoaPowder()
        };
    }

    private void PrintIngredients(List<Ingredient> ingredientsAvailable)
    {
        Console.WriteLine("Printing available ingredients: ");
        foreach (Ingredient ingredient in ingredientsAvailable)
        {
            Console.WriteLine($"{ingredient.Id}. {ingredient.Name}\n");
        }
    }
}

public abstract class Ingredient
{
    public int Id { get; }
    public string Name { get; }

    public Ingredient(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public abstract string Instructions();
}

public class Recipe
{
    public List<Ingredient> ingredients;

    public string BuildRecipe()
    {
        string recipe = "";

        foreach(Ingredient ingredient in ingredients)
        {
            recipe += $"{ingredient.Name}. {ingredient.Instructions()}\n";
        }

        return recipe;
    }

    public void Add(Ingredient ingredient)
    {
        ingredients.Add(ingredient);
    }

    public bool isEmpty()
    {
        return ingredients.Count == 0;
    }

    public string GetIds()
    {
        string ids = "";

        foreach(Ingredient ingredient in ingredients)
        {
            ids += ingredient.Id;
        }

        return ids;
    }
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
    public string Load(string fileName);
}

public class RecipeRepositoryJson : StringTextualRepository
{
    public string Load(string fileName)
    {
        throw new NotImplementedException();
    }

    public void Save(string text)
    {
        throw new NotImplementedException();
    }
}

public class RecipeRepositoryTxt : StringTextualRepository
{
    public string Load(string fileName)
    {
        throw new NotImplementedException();
    }

    public void Save(string text)
    {
        throw new NotImplementedException();
    }
}

public class WheatFlour : Ingredient
{
    public WheatFlour() : base(1, "Wheat Flour") { }

    public override string Instructions()
    {
        return "Sieve. Add to the other ingredients.";
    }
}

public class CoconutFlour : Ingredient
{
    public CoconutFlour() : base(2, "Coconut Flour") { }

    public override string Instructions()
    {
        return "Sieve. Add to the other ingredients.";
    }
}

public class Butter : Ingredient
{
    public Butter() : base(3, "Butter") { }

    public override string Instructions()
    {
        return "Melt on low heat. Add to other ingredients.";
    }
}

public class Chocolate : Ingredient
{
    public Chocolate() : base(4, "Chocolate") { }

    public override string Instructions()
    {
        return "Melt in a water bath. Add to other ingredients.";
    }
}

public class Sugar : Ingredient
{
    public Sugar() : base(5, "Sugar") { }

    public override string Instructions()
    {
        return "Add to other ingredients.";
    }
}

public class Cardamom : Ingredient
{
    public Cardamom() : base(6, "Cardamom") { }

    public override string Instructions()
    {
        return "Take half a teaspoon. Add to other ingredients.";
    }
}

public class Cinnamon : Ingredient
{
    public Cinnamon() : base(7, "Cinnamon") { }

    public override string Instructions()
    {
        return "Take half a teaspoon. Add to other ingredients.";
    }
}

public class CocoaPowder : Ingredient
{
    public CocoaPowder() : base(8, "Cocoa Powder") { }

    public override string Instructions()
    {
        return "Add to other ingredients.";
    }
}

public enum FileFormat
{
    Json,
    Txt
}