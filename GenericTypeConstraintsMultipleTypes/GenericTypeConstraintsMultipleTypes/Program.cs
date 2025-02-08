
Console.ReadKey();

void SomeMethod<TPet, TOwner>(TPet pet, TOwner owner) where TPet: Pet, IComparable<TPet> where TOwner : new()
{

}

public class Pet { }
public class PetOwner { }