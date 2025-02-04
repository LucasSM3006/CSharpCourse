using System.Linq.Expressions;

try
{
var dataFromWeb = SendHttpRequest("https://www.joshua.com");
}
// catch (HttpRequestException ex) when (ex.Message.StartsWith("4")) // Commented out due to it catching all error 400's. This block is above, so it'll be the one to execute instead of the ones below.
// {
//    Console.WriteLine("Some kind of client error");
//    throw;
// }
catch (HttpRequestException ex) when (ex.Message == "403")
{
    Console.WriteLine("Forbidden access to the resource");
    throw;
}
catch (HttpRequestException ex) when (ex.Message == "404")
{
    Console.WriteLine("Resource not found");
    throw;
}
catch (HttpRequestException ex) when (ex.Message == "500")
{
    Console.WriteLine("The server has experience an internal error");
    throw;
}


Console.ReadKey();



string SendHttpRequest(string link)
{
    string response;

    // implemnt
    response = "boss";

    return response;
}