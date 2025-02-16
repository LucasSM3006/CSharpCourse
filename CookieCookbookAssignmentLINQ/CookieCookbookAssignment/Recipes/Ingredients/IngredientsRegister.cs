namespace CookieCookbookAssignment.Recipes.Ingredients;

public class IngredientsRegister : IIngredientsRegister
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

    public Ingredient GetById(int id)
    {
        var countOfIngredientsWithGivenId = All.Where(ingredient => ingredient.Id == id);

        if(countOfIngredientsWithGivenId.Count() > 1)
        {
            throw new InvalidOperationException($"Duplicate elements found! Id is: {id}");
        }

        //if(All.Select(ingredient => ingredient.Id).Distinct().Count() != All.Count())
        //{
        //    throw new InvalidOperationException($"Some ingredients have duplicate ids.");
        //}

        return countOfIngredientsWithGivenId.FirstOrDefault();
    }
}
