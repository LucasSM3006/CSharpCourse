var internationalPizzaDay25 = new DateTime(2025, 2, 9);
var today = new DateTime(2025, 1, 22);

Console.WriteLine($"Year is: {internationalPizzaDay25.Year}");
Console.WriteLine($"Month is: {internationalPizzaDay25.Month}");
Console.WriteLine($"Day is: {internationalPizzaDay25.Day}");
Console.WriteLine($"Day of the week will be: {internationalPizzaDay25.DayOfWeek}");

Console.WriteLine();

var internationalPizzaDay35 = internationalPizzaDay25.AddYears(10);

Console.WriteLine($"Year is: {internationalPizzaDay35.Year}");
Console.WriteLine($"Month is: {internationalPizzaDay35.Month}");
Console.WriteLine($"Day is: {internationalPizzaDay35.Day}");
Console.WriteLine($"Day of the week will be: {internationalPizzaDay35.DayOfWeek}");

Console.ReadKey();