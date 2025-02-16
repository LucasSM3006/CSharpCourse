using CookieCookbookAssignment.Recipes.Ingredients;
using CookieCookbookAssignment.Recipes;

namespace CookieCookbookAssignment.App;

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
        Console.WriteLine(string.Join(Environment.NewLine, _ingredientsRegister.All));
    }

    public void PrintExistingRecipes(IEnumerable<Recipe> recipes)
    {
        if (recipes.Count() > 0)
        {
            Console.WriteLine("Existing recipes are: " + Environment.NewLine); // Newline's better to use than '\n'. Apparently it can cause issues due to different OS's.

            //int counter = 0;

            //var recipesAsStrings = recipes.Select(recipe =>
            //{
            //    var str = $"*****{counter + 1}*****{Environment.NewLine}{recipe}{Environment.NewLine}";
            //    counter++;
            //    return str;
            //}); // My way of doing it.

            // Professor's way of doing it.

            var recipesAsStrings = recipes
                .Select((recipe, index) => // The index is already from the list, so the counter variable isn't necessary.
                $@"*****{index + 1}*****
{recipe}");

            Console.WriteLine(string.Join(Environment.NewLine, recipesAsStrings));
            Console.WriteLine();
        }
    }

    public IEnumerable<Ingredient> ReadIngredientsFromUser()
    {
        List<Ingredient> ingredients = new List<Ingredient>();

        bool shallStop = false;

        while (!shallStop)
        {
            Console.WriteLine("Add an ingredient by its ID or write anything else if finished.");

            string userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int id))
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
