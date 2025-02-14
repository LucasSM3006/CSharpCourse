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


// Any method.

if(randomWords.Any(word => word.Length == 1))
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

// Now for the opposite of Any(), All().

bool areAllBiggerThanZero = numbers.All(number => number > 0);
bool areAllWordsBiggerThanOneInLength = randomWords.All(word => word.Length > 1);
bool areAllPetsLargerThanZeroKilograms = pets.All(pet => pet.Weight > 0);

if(areAllBiggerThanZero) Console.WriteLine("All numbers larger than zero");
if(areAllWordsBiggerThanOneInLength) Console.WriteLine("All words are bigger than one in length");
if(areAllPetsLargerThanZeroKilograms) Console.WriteLine("All pets have a weight higher than zero");

// Count and LongCount.

var countOfFish = pets.Count(pet => pet.Type == PetType.Fish);
var countOfDogs = pets.Count(pet => pet.Type == PetType.Dog);
var countOfCats = pets.Count(pet => pet.Type == PetType.Cat);

Console.WriteLine($"Count of fish is {countOfFish}; Count of dogs is {countOfDogs}; Count of cats is {countOfCats}");

var countOfNumbersBiggerThanTen = numbers.Count(number => number > 10);
// If the value in question was higher than the maximum value of int, which is 2,147,483,647, we instead use CountLong.

var countOfFishNamedAqua = pets.LongCount(pet => pet.Name.Equals("Aqua"));
Console.WriteLine($"Count of fish named Aqua: {countOfFishNamedAqua}");

Console.WriteLine($"Count of numbers bigger than ten in the numbers array: {countOfNumbersBiggerThanTen}");

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