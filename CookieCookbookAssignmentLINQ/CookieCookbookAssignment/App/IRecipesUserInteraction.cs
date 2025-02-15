using CookieCookbookAssignment.Recipes.Ingredients;
using CookieCookbookAssignment.Recipes;

namespace CookieCookbookAssignment.App;

public interface IRecipesUserInteraction
{
    public void ShowMessage(string message);
    public void PromptToCreateRecipes();
    public void PrintExistingRecipes(IEnumerable<Recipe> recipes); // When in doubt, pick a general type...
    public IEnumerable<Ingredient> ReadIngredientsFromUser();
    public void Exit();
}
