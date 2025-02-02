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
        List<string> recipesAsStrings = new List<string>();

        foreach (Recipe recipe in recipes)
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

        foreach (string recipeFromFile in recipesFromFile)
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

        foreach (var textualId in textualIds) // Iterates through the list of strings. The one we separated earlier.
        {
            int id = int.Parse(textualId); // Turns it from a string into an integer.
            Ingredient ingredient = _ingredientsRegister.GetById(id);
            ingredients.Add(ingredient);
        }

        return new Recipe(ingredients); // Returns a new Recipe with the ingredient list.
    }
}
