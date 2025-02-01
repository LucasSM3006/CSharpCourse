using CookieCookbookAssignment.Recipes;
using CookieCookbookAssignment.Recipes.Ingredients;
using System.Diagnostics.Metrics;

RecipesConsoleUserInteraction console = new RecipesConsoleUserInteraction();
TextRecipesRepository repository = new TextRecipesRepository();

CookiesRecipeApplication app = new CookiesRecipeApplication(repository, console);



app.Run("recipes.txt");

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
        List<Recipe> allRecipes = _recipesRepository.Load();
        _recipesUserInteraction.PrintExistingRecipes(allRecipes);

        _recipesUserInteraction.PromptToCreateRecipes();

        //List<Ingredient> ingredients = _recipesUserInteraction.ReadIngredientsFromUser();

        //if(ingredients.Count > 0)
        //{
        //    Recipe recipe = new Recipe(ingredients);

        //    allRecipes.Add(recipe);

        //    _recipesRepository.Write(filePath, allRecipes);

        //    _recipesUserInteraction.ShowMessage("Recipe added: ");
        //    _recipesUserInteraction.ShowMessage(recipe.ToString());
        //}
        //else
        //{
        //    _recipesUserInteraction.ShowMessage("No ingredients added, recipe won't be saved.");
        //}

        _recipesUserInteraction.Exit();
    }
}

public interface IRecipesUserInteraction
{
    public void ShowMessage(string message);
    public void PromptToCreateRecipes();
    public void PrintExistingRecipes(IEnumerable<Recipe> recipes); // When in doubt, pick a general type...
    public void Exit();
}

public class IngredientsRegister
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
}

public class RecipesConsoleUserInteraction : IRecipesUserInteraction
{
    private readonly IngredientsRegister _ingredientsRegister;

    public RecipesConsoleUserInteraction(IngredientsRegister ingredientsRegister)
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
            Console.WriteLine($"{ingredient.Id}. {ingredient.Name}");
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

    public void Exit()
    {
        Console.WriteLine("Press any key to close.");
        Console.ReadKey();
    }
}

public interface IRecipesRepository
{
    public void Save(List<Recipe> recipes);
    public List<Recipe> Load();
}

public class TextRecipesRepository : IRecipesRepository
{
    public void Save(List<Recipe> recipes)
    {

    }

    // Dummy method for testing. Will implement later.
    public List<Recipe> Load()
    {
        return new List<Recipe>
        {
            new Recipe(new List<Ingredient>
            {
                new CocoaPowder(),
                new Butter(),
                new Sugar()
            }),
            new Recipe(new List<Ingredient>
            {
                new Chocolate(),
                new Sugar(),
                new Cinnamon()
            }),
            new Recipe(new List<Ingredient>
            {
                new Sugar(),
                new Sugar(),
                new Chocolate(),
                new Butter(),
                new Cinnamon()
            })
        };
    }
}

public class JsonRecipesRepository : IRecipesRepository
{
    public void Save(List<Recipe> recipes)
    {

    }

    public List<Recipe> Load()
    {
        throw new NotImplementedException();
    }
}