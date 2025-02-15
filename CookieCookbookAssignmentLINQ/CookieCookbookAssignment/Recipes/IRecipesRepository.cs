using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieCookbookAssignment.Recipes;

public interface IRecipesRepository
{
    public void Write(string filePath, List<Recipe> recipes);
    public List<Recipe> Load(string filePath);
}
