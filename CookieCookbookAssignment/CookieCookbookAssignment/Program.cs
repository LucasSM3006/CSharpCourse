CookiesRecipeApplication app = new CookiesRecipeApplication();
app.Run();

public class CookiesRecipeApplication
{
    private readonly RecipesRepository _recipesRepository;
    private readonly RecipesUserInteraction _recipesUserInteraction;

    public CookiesRecipeApplication(RecipesRepository recipesRepository, RecipesUserInteraction recipesUserInteraction)
    {
        _recipesRepository = recipesRepository;
        _recipesUserInteraction = recipesUserInteraction;
    }

    public void Run()
    {
        RecipesRepository allRecipes = _recipesRepository.Load();
        _recipesUserInteraction.PrintExistingRecipes(allRecipes);
    }
}



public class Recipe
{

}

public class Ingredient
{

}