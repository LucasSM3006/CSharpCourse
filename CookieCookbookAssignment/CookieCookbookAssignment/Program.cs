using CookieCookbookAssignment.Recipes;
using CookieCookbookAssignment.Recipes.Ingredients;
using Microsoft.VisualBasic;
using System.Diagnostics.Metrics;
using System.Text.Json;

IngredientsRegister ingredientsRegister1 = new IngredientsRegister();
RecipesConsoleUserInteraction console = new RecipesConsoleUserInteraction(ingredientsRegister1);
TextRecipesRepository repository = new TextRecipesRepository(new StringsJsonRepository(), ingredientsRegister1);

CookiesRecipeApplication app = new CookiesRecipeApplication(repository, console);



app.Run("recipes.json");

public class CookiesRecipeApplication
{
    private readonly IRecipesRepository _recipesRepository;
    private readonly IRecipesUserInteraction _recipesUserInteraction;

    public CookiesRecipeApplication(IRecipesRepository recipesRepository, IRecipesUserInteraction recipesUserInteraction)
    {
        _recipesRepository = recipesRepository;
        _recipesUserInteraction = recipesUserInteraction;
    }

    public void Run(string filePath)
    {
        List<Recipe> allRecipes = _recipesRepository.Load(filePath);
        _recipesUserInteraction.PrintExistingRecipes(allRecipes);

        _recipesUserInteraction.PromptToCreateRecipes();

        IEnumerable<Ingredient> ingredients = _recipesUserInteraction.ReadIngredientsFromUser();

        if(ingredients.Count() > 0)
        {
            Recipe recipe = new Recipe(ingredients);

            allRecipes.Add(recipe);

            _recipesRepository.Write(filePath, allRecipes);

            _recipesUserInteraction.ShowMessage("Recipe added: ");
            _recipesUserInteraction.ShowMessage(recipe.ToString());
        }
        else
        {
            _recipesUserInteraction.ShowMessage("No ingredients added, recipe won't be saved.");
        }

        _recipesUserInteraction.Exit();
    }
}

public interface IRecipesUserInteraction
{
    public void ShowMessage(string message);
    public void PromptToCreateRecipes();
    public void PrintExistingRecipes(IEnumerable<Recipe> recipes); // When in doubt, pick a general type...
    public IEnumerable<Ingredient> ReadIngredientsFromUser();
    public void Exit();
}

public interface IIngredientsRegister
{
    IEnumerable<Ingredient> All { get; }

    Ingredient GetById(int id);
}

public class IngredientsRegister : IIngredientsRegister
{
    public IEnumerable<Ingredient> All { get; } = new List<Ingredient>
    {
        new WheatFlour(),
        new CoconutFlour(),
        new Butter(),
        new Chocolate(),
        new Sugar(),
        new Cardamon(),
        new Cinnamon(),
        new CocoaPowder()
    };

    public Ingredient GetById(int id)
    {
        foreach (Ingredient ingredient in All)
        {
            if (ingredient.Id == id) return ingredient;
        }

        return null;
    }
}

public class RecipesConsoleUserInteraction : IRecipesUserInteraction
{
    private readonly IIngredientsRegister _ingredientsRegister;

    public RecipesConsoleUserInteraction(IIngredientsRegister ingredientsRegister)
    {
        _ingredientsRegister = ingredientsRegister;
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    public void PromptToCreateRecipes()
    {
        Console.WriteLine("Create a cookie recipe! Available ingredients are:");

        foreach(Ingredient ingredient in _ingredientsRegister.All)
        {
            Console.WriteLine(ingredient);
        }
    }

    public void PrintExistingRecipes(IEnumerable<Recipe> recipes)
    {
        if(recipes.Count() > 0)
        {
            Console.WriteLine("Existing recipes are: " + Environment.NewLine); // Newline's better to use than '\n'. Apparently it can cause issues due to different OS's.

            int counter = 0;

            foreach(Recipe recipe in recipes)
            {
                Console.WriteLine($"*****{counter + 1}*****");
                Console.WriteLine(recipe);
                Console.WriteLine();
                counter++;
            }
        }
    }

    public IEnumerable<Ingredient> ReadIngredientsFromUser()
    {
        List<Ingredient> ingredients = new List<Ingredient>();

        bool shallStop = false;

        while(!shallStop)
        {
            Console.WriteLine("Add an ingredient by its ID or write anything else if finished.");

            string userInput = Console.ReadLine();

            if(int.TryParse(userInput, out int id))
            {
                var selectedIngredient = _ingredientsRegister.GetById(id);
                if (selectedIngredient is not null) ingredients.Add(selectedIngredient);
            }
            else
            {
                shallStop = true;
            }
            
        }

        return ingredients;
    }

    public void Exit()
    {
        Console.WriteLine("Press any key to close.");
        Console.ReadKey();
    }
}

public interface IRecipesRepository
{
    public void Write(string filePath, List<Recipe> recipes);
    public List<Recipe> Load(string filePath);
}

public interface IStringsRepository
{
    List<string> Read(string filename);
    void Write(string filePath, List<string> strings);
}

public class TextRecipesRepository : IRecipesRepository
{
    private readonly IStringsRepository _stringsRepository;
    private readonly IIngredientsRegister _ingredientsRegister;
    private const string Separator = ",";

    public TextRecipesRepository(
        IStringsRepository stringsRepository,
        IIngredientsRegister ingredientsRegister)
    {
        _stringsRepository = stringsRepository;
        _ingredientsRegister = ingredientsRegister;
    }

    public void Write(string filePath, List<Recipe> recipes)
    {
        List<string> recipesAsStrings = new List<string>();

        foreach(Recipe recipe in recipes)
        {
            List<int> allIds = new List<int>();

            foreach (Ingredient ingredient in recipe.Ingredients)
            {
                allIds.Add(ingredient.Id);
            }
            recipesAsStrings.Add(string.Join(",", allIds));
        }

        _stringsRepository.Write(filePath, recipesAsStrings);
    }

    // Dummy method for testing. Will implement later.
    public List<Recipe> Load(string filePath)
    {
        List<string> recipesFromFile = _stringsRepository.Read(filePath);

        List<Recipe> recipes = new List<Recipe>();

        foreach(string recipeFromFile in recipesFromFile)
        {
            Recipe recipe = RecipeFromString(recipeFromFile);
            recipes.Add(recipe);
        }

        return recipes;
    }

    private Recipe RecipeFromString(string recipeFromFile)
    {
        IEnumerable<string> textualIds = recipeFromFile.Split(Separator); // Splits the string.
        List<Ingredient> ingredients = new List<Ingredient>(); // Creates a new list holding ingredients.

        foreach(var textualId in textualIds) // Iterates through the list of strings. The one we separated earlier.
        {
            int id = int.Parse(textualId); // Turns it from a string into an integer.
            Ingredient ingredient = _ingredientsRegister.GetById(id);
            ingredients.Add(ingredient);
        }

        return new Recipe(ingredients); // Returns a new Recipe with the ingredient list.
    }
}


// Class previously made in another lecture.
public class StringsTextualRepository : IStringsRepository
{
    private static readonly string Separator = Environment.NewLine;

    public List<string> Read(string filename)
    {
        if(File.Exists(filename))
        {
            var fileContents = File.ReadAllText(filename);
            return fileContents.Split(Separator).ToList();
        }
        return new List<string>();
    }

    public void Write(string filePath, List<string> strings)
    {
        File.WriteAllText(filePath, string.Join(Separator, strings));
    }
}

public class StringsJsonRepository : IStringsRepository
{
    public List<string> Read(string filename)
    {
        if (File.Exists(filename))
        {
            var fileContents = File.ReadAllText(filename);
            return JsonSerializer.Deserialize<List<string>>(fileContents);
        }
        return new List<string>();
    }

    public void Write(string filePath, List<string> strings)
    {
        File.WriteAllText(filePath, JsonSerializer.Serialize(strings));
    }
}