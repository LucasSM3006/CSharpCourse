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



public class Recipe
{

}

public class Ingredient
{

}