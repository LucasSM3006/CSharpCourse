// Key and Pair relationship.
Dictionary<string, string> countryToCurrencyMapping = new Dictionary<string, string>();

countryToCurrencyMapping.Add("US", "USD");
countryToCurrencyMapping.Add("CA", "CAD");
countryToCurrencyMapping.Add("BR", "BRL");
countryToCurrencyMapping.Add("AU", "AUD");
countryToCurrencyMapping.Add("UK", "GBP");
countryToCurrencyMapping.Add("DE", "EUR");

Console.WriteLine($"Currency in the US is: {countryToCurrencyMapping["US"]}");
Console.WriteLine($"Currency in the UK is: {countryToCurrencyMapping["UK"]}");

// countryToCurrencyMapping.Add("US","USD"); // Causes an exception, keys must be unique.

countryToCurrencyMapping["NZ"] = "NZD";
countryToCurrencyMapping["NZ"] = "NZD"; // Doesn't throw an exception because we're not adding, if it does already exist, then it'll set the value of the key to the new value.

Console.WriteLine($"Currency in NZ is: {countryToCurrencyMapping["NZ"]}");

Dictionary<string, string> countryToCurrencyMappingALT = new Dictionary<string, string>
{
    { "BRA", "REAL" },
    { "USA", "US DOLLAR" },
    { "POL", "EURO" }
};


Dictionary<string, string> countryToCurrencyMappingALT2 = new Dictionary<string, string>
{
    ["BRA"] = "REAL",
    ["USA"] = "US DOLLAR",
    ["POL"] = "EURO"
};

// Console.WriteLine($"Currency in non existent country is {countryToCurrencyMapping["NULL COUNTRY"]}"); // Will throw an exception, "KeyNotFoundException"

if(countryToCurrencyMappingALT2.ContainsKey("BR"))
{
    Console.WriteLine("Contains");
} else
{
    Console.WriteLine("Doesn't contain it");
}

foreach (KeyValuePair<string, string> key in countryToCurrencyMapping)
{
    Console.WriteLine(key); // Prints out the key and value like this: [ KEY, VALUE ]

    Console.WriteLine($"Country: {key.Key}, Currency: {key.Value}");
}

Console.ReadKey();