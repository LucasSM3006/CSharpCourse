using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookieCookbookAssignment.Recipes.Ingredients;

namespace CookieCookbookAssignment.Recipes
{
    public class Recipe
    {
        public IEnumerable<Ingredient> Ingredients { get; }

        public Recipe(IEnumerable<Ingredient> ingredients)
        {
            Ingredients = ingredients;
        }

        public override string ToString()
        {
            List<string> allIngredients = new List<string>();

            foreach(Ingredient ingredient in Ingredients)
            {
                allIngredients.Add($"{ingredient.Name}. {ingredient.PreparationInstructions}");
            }

            return string.Join(Environment.NewLine, allIngredients);
        }
    }
}
