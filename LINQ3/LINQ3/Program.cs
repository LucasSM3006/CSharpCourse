// Note: Linq does not modify the input, it instead creates a new one.

var numbers = new List<int> { 5, 3, 7, 1, 2, 4 };
var numbersWith10 = numbers.Append(10);

// Despite appending ten to it on the line above, the input, 'numbers' remained unmodified.

Console.WriteLine($"Numbers without appending 10: {{ {string.Join(", ", numbers)} }}");
Console.WriteLine($"Numbers with appending 10: {{ {string.Join(", ", numbersWith10)} }}");

// Another example;

var oddNumbers = numbers.Where(number => number % 2 != 0);
var orderedOddNumbers = oddNumbers.OrderBy(number => number);

// It's very similar to streams in Java, but much simpler..
var orderedOddNumbersALT = numbers
    .Where(number => number % 2 != 0)
    .OrderBy(number => number);
// Code above is method chaining.

Console.WriteLine($"Odd numbers: {{ {string.Join(", ", oddNumbers)} }}");
Console.WriteLine($"Ordered numbers: {{ {string.Join(", ", orderedOddNumbers)} }}");
Console.WriteLine($"Ordered numbers ALT: {{ {string.Join(", ", orderedOddNumbersALT)} }}");

Console.WriteLine("Hello!");

var randomWords = new List<string> { "aaaaa", "bbasdfas", "buffon", "verylongword", "o"};

// *****************************************************************
// Any method.
// *****************************************************************

if (randomWords.Any(word => word.Length == 1))
{
    Console.WriteLine("There's one word in the list with a length of one.");
}

if(randomWords.Any(word => word.StartsWith('a')))
{
    Console.WriteLine("There's one word in the list that starts with 'a'.");
}

var randomNumbers = new[] { 5, 9, 8, 12, 200 };

if(randomNumbers.Any(number => number > 10))
{
    Console.WriteLine("There's a number larger than 10!");
}

bool isAnyLargerThan100 = randomNumbers.Any(number => number > 100);

if(isAnyLargerThan100)
{
    Console.WriteLine("There's a number larger than 100.");
}

var pets = new[]
{
    new Pet(1, "Alik", PetType.Fish, 0.2),
    new Pet(2, "Arque", PetType.Dog, 0.2),
    new Pet(3, "Ronaldo", PetType.Cat, 0.2),
    new Pet(4, "Ezekiel", PetType.Fish, 0.2),
    new Pet(5, "Judas", PetType.Cat, 0.2),
    new Pet(6, "Loah", PetType.Dog, 0.2),
    new Pet(7, "Alga", PetType.Fish, 0.01),
    new Pet(8, "Aqua", PetType.Fish, 240.5)
};

var isAnyPetNamedArque = pets.Any(pet => pet.Name.Equals("Arque"));

if(isAnyPetNamedArque)
{
    Console.WriteLine("Someone is named arque");
}

var isAnyPetAFishNamedAquaThatWeighsOverAHundred = pets.Any(pet => pet.Type.Equals(PetType.Fish) && pet.Name.Equals("Aqua") && pet.Weight > 100);

if(isAnyPetAFishNamedAquaThatWeighsOverAHundred)
{
    Console.WriteLine("Yep, there's an Aqua here.");
}

// *****************************************************************
// Now for the opposite of Any(), All().
// *****************************************************************

bool areAllBiggerThanZero = numbers.All(number => number > 0);
bool areAllWordsBiggerThanOneInLength = randomWords.All(word => word.Length > 1);
bool areAllPetsLargerThanZeroKilograms = pets.All(pet => pet.Weight > 0);

if(areAllBiggerThanZero) Console.WriteLine("All numbers larger than zero");
if(areAllWordsBiggerThanOneInLength) Console.WriteLine("All words are bigger than one in length");
if(areAllPetsLargerThanZeroKilograms) Console.WriteLine("All pets have a weight higher than zero");

// *****************************************************************
// Count and LongCount.
// *****************************************************************

var countOfFish = pets.Count(pet => pet.Type == PetType.Fish);
var countOfDogs = pets.Count(pet => pet.Type == PetType.Dog);
var countOfCats = pets.Count(pet => pet.Type == PetType.Cat);

Console.WriteLine($"Count of fish is {countOfFish}; Count of dogs is {countOfDogs}; Count of cats is {countOfCats}");

var countOfNumbersBiggerThanTen = numbers.Count(number => number > 10);
// If the value in question was higher than the maximum value of int, which is 2,147,483,647, we instead use CountLong.

var countOfFishNamedAqua = pets.LongCount(pet => pet.Name.Equals("Aqua"));
Console.WriteLine($"Count of fish named Aqua: {countOfFishNamedAqua}");

Console.WriteLine($"Count of numbers bigger than ten in the numbers array: {countOfNumbersBiggerThanTen}");

// *****************************************************************
// Contains method, checks if a certain element is in a collection.
// *****************************************************************
bool is3PresentInNumbers = numbers.Contains(3);

if(is3PresentInNumbers) Console.WriteLine("3 is present.");

bool is100PresentInNumbers = numbers.Contains(100);

if(is100PresentInNumbers) Console.WriteLine("100 is present.");

// *****************************************************************
// OrderBy, OrderByDescending, ThenBy and ThenByDescending.
// *****************************************************************

var petsOrderedByName = pets.OrderBy(pet => pet.Name);
var orderedNumbers = numbers.OrderBy(number => number);
var orderedStringsDescending = randomWords.OrderByDescending(word => word);
var petsOrderedByIdDescending = pets.OrderByDescending(pet => pet.Id);

foreach (var pet in petsOrderedByName)
{
    Console.WriteLine(pet.Name);
}

Console.WriteLine();

foreach(var number in orderedNumbers)
{
    Console.WriteLine(number);
}

Console.WriteLine();

foreach (var word in orderedStringsDescending)
{
    Console.WriteLine(word);
}

Console.WriteLine();

foreach (var pet in petsOrderedByIdDescending)
{
    Console.WriteLine(pet.Id);
}

Console.WriteLine();

// ThenBy.

var petsOrderedByTypeThenName = pets
    .OrderBy(pet => pet.Type)
    .ThenBy(pet => pet.Name);

foreach(var pet in petsOrderedByTypeThenName)
{
    Console.WriteLine(pet.Type);
    Console.WriteLine(pet.Name);
}

Console.WriteLine();

// *****************************************************************
// First and Last.
// *****************************************************************

// They also throw exceptions, so make sure they're not empty.
var firstPet = pets.First();
var lastPet = pets.Last();
var firstNumber = orderedNumbers.First();
var lastNumber = orderedNumbers.Last();

Pet firstPetThatNameStartsWithA = pets.First(pet => pet.Name.StartsWith("A"));
var firstOdd = orderedNumbers.First(n => n % 2 != 0);

// Ie, this would throw an exception: Sequence contains no matching element.
// Pet lastDog = pets.Last(pet => pet.Weight > 500);
Pet lastDog = pets.LastOrDefault(pet => pet.Weight > 500); // Returns the default value if there's nothing that matches the criteria given.

var heaviestPet = pets.OrderBy(pet => pet.Weight).Last();


// *****************************************************************
// Where.
// *****************************************************************

var evenNumbers = numbers.Where(number => number % 2 == 0);
var petsBelow10KG = pets.Where(pet => pet.Weight < 10);
var petsAbove10KG = pets.Where(pet => pet.Weight > 10);
var petsWith10KG = pets.Where(pet => pet.Weight == 10);

var specificPets = pets.Where(pet => pet.Type == PetType.Cat && pet.Weight > 2 && (pet.Name.StartsWith("A") || pet.Name.StartsWith("R")));

// A more complex one.

var indexesSelectedByUser = new[] { 1, 6, 7 };
var petsSelectedByUserAndBelow5kg = pets
    .Where((pet, index) =>
        pet.Weight < 5 &&
        indexesSelectedByUser.Contains(index));

foreach (var number in evenNumbers)
{
    Console.WriteLine(number);
}

foreach (var pet in petsSelectedByUserAndBelow5kg)
{
    Console.WriteLine(pet.Name);
}

Console.ReadKey();

public class Pet
{
    public int Id { get; set; }
    public string Name { get; set; }
    public PetType Type { get; set; }
    public double Weight { get; set; }

    public Pet(int id, string name, PetType type, double weight)
    {
        Id = id;
        Name = name;
        Type = type;
        Weight = weight;
    }
}

public enum PetType
{
    Fish,
    Dog,
    Cat
}