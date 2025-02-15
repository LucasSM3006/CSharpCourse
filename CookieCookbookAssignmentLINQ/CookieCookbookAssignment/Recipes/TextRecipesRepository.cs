using CookieCookbookAssignment.DataAccess;
using CookieCookbookAssignment.Recipes.Ingredients;

namespace CookieCookbookAssignment.Recipes;

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
    //    List<string> recipesAsStrings = recipes.Select(recipe => string
    //.Join(",", recipe.Ingredients.Select(ingredient => ingredient.Id))).ToList();

        List<string> recipesAsStrings = recipes.Select(recipe =>
        {
            var allIds = recipe.Ingredients.Select(ingredient => ingredient.Id);
            return string.Join(Separator, allIds);
        }).ToList();

        _stringsRepository.Write(filePath, recipesAsStrings);
    }

    // Dummy method for testing. Will implement later.
    public List<Recipe> Load(string filePath)
    {
        return _stringsRepository
            .Read(filePath)
            .Select(RecipeFromString)
            .ToList(); 
    }

    private Recipe RecipeFromString(string recipeFromFile)
    {
        var ingredients = recipeFromFile.Split(Separator)
            .Select(int.Parse)
            .Select(_ingredientsRegister.GetById);

        return new Recipe(ingredients); // Returns a new Recipe with the ingredient list.
    }
}
