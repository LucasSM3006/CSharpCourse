RecipesConsoleUserInteraction console = new RecipesConsoleUserInteraction();
TextRecipesRepository repository = new TextRecipesRepository();

CookiesRecipeApplication app = new CookiesRecipeApplication(repository, console);

app.Run();

public class CookiesRecipeApplication
{
    private readonly IRecipesRepository _recipesRepository;
    private readonly IRecipesUserInteraction _recipesUserInteraction;

    public CookiesRecipeApplication(IRecipesRepository recipesRepository, IRecipesUserInteraction recipesUserInteraction)
    {
        _recipesRepository = recipesRepository;
        _recipesUserInteraction = recipesUserInteraction;
    }

    public void Run()
    {
        IRecipesRepository allRecipes = _recipesRepository.Load();
        _recipesUserInteraction.PrintExistingRecipes(allRecipes);

        _recipesUserInteraction.PromptToCreateRecipes();

        List<Ingredient> ingredients = _recipesUserInteraction.ReadIngredientsFromUser();

        if(ingredients.Count > 0)
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
    public void PrintExistingRecipes(List<Recipe> recipes);
    public void Exit();
}

public class RecipesConsoleUserInteraction : IRecipesUserInteraction
{
    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    public void PromptToCreateRecipes()
    {

    }

    public void PrintExistingRecipes(List<Recipe> recipes)
    {

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

    public List<Recipe> Load()
    {
        throw new NotImplementedException();
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