/*
 * Dictionaries - FindMaxWeights of pets

Implement the FindMaxWeights method, which takes a collection of Pets (each having PetType and Weight properties) and returns a dictionary with a mapping from the PetType to the maximal weight of pets of this type.

For example, for the following input List:

    Dog, 10 kilos
    Cat, 5 kilos
    Fish, 0.9 kilos
    Dog, 45 kilos
    Cat, 2 kilos
    Fish, 0.02 kilos 

The result shall be a Dictionary like this:

    Key: Dog, Value: 45
    Key: Cat, Value: 5
    Key: Fish, Value: 0.9 

Because the max weight for dogs is 45, for cats is 5, and for fish is 0.9 kilos.
 * 
 * 
 */

List<Pet> pets = new List<Pet>
{
    new Pet(PetType.Dog, 10),
    new Pet(PetType.Cat, 5),
    new Pet(PetType.Fish, 0.9),
    new Pet(PetType.Dog, 45),
    new Pet(PetType.Cat, 2),
    new Pet(PetType.Fish, 0.02),
};

Dictionary<PetType, double> maxWeightPerCategory = Exercise.FindMaxWeights(pets);

foreach(var max in maxWeightPerCategory)
{
    Console.WriteLine($"Pet type: {max.Key}, Maximum weight is: {max.Value}");
}


Console.ReadKey();

public static class Exercise
{
    public static Dictionary<PetType, double> FindMaxWeights(List<Pet> pets)
    {
        Dictionary<PetType, List<Pet>> petsDictionary = new Dictionary<PetType, List<Pet>>();

        foreach (Pet pet in pets)
        {
            if (!petsDictionary.ContainsKey(pet.PetType))
            {
                petsDictionary[pet.PetType] = new List<Pet>();
            }

            petsDictionary[pet.PetType].Add(pet);
        }

        Dictionary<PetType, double> maxPerCategory = new Dictionary<PetType, double>();

        foreach (var petsInCategory in petsDictionary)
        {
            double max = 0;

            foreach(var p in petsInCategory.Value)
            {
                if(p.Weight > max)
                {
                    max = p.Weight;
                }
            }

            maxPerCategory[petsInCategory.Key] = max;
        }

        return maxPerCategory;
    }
}

public class Pet
{
    public PetType PetType { get; }
    public double Weight { get; }

    public Pet(PetType petType, double weight)
    {
        PetType = petType;
        Weight = weight;
    }

    public override string ToString() => $"{PetType}, {Weight} kilos";
}

public enum PetType { Dog, Cat, Fish }