using CookieCookbookAssignment.App;
using CookieCookbookAssignment.DataAccess;
using CookieCookbookAssignment.FileAccess;
using CookieCookbookAssignment.Recipes;
using CookieCookbookAssignment.Recipes.Ingredients;

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