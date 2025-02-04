using CookieCookbookAssignment.App;
using CookieCookbookAssignment.DataAccess;
using CookieCookbookAssignment.FileAccess;
using CookieCookbookAssignment.Recipes;
using CookieCookbookAssignment.Recipes.Ingredients;

try
{
    const FileType format = FileType.Json;
    const string fileName = "recipes";

    FileMetaData fileMetaData = new FileMetaData(fileName, format);

    IStringsRepository stringsRepository = format == FileType.Json ?
        new StringsJsonRepository() :
        new StringsTextualRepository();

    IngredientsRegister ingredientsRegister1 = new IngredientsRegister();
    RecipesConsoleUserInteraction console = new RecipesConsoleUserInteraction(ingredientsRegister1);
    TextRecipesRepository repository = new TextRecipesRepository(stringsRepository, ingredientsRegister1);

    CookiesRecipeApplication app = new CookiesRecipeApplication(repository, console);

    app.Run(fileMetaData.ToPath());
}
catch (Exception ex)
{
    Console.WriteLine("Unexpected error! The application will close.");
    Console.WriteLine($"Error message: {ex.Message}");
    Console.WriteLine("Press any key to close.");
    Console.ReadKey();
}