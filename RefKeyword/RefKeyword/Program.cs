int number = 5;

AddOneToNumber(ref number);

Console.WriteLine($"Number is: {number}");

MethodWithOutParameter(out int otherNumber);

Console.WriteLine($"Number is: {otherNumber}");


// Using "ref" with reference types.
var list = new List<int> { 1, 2, 3 };
var listRef = new List<int> { 1, 2, 3 };

foreach (int i in list)
{
    Console.WriteLine(i);
}

AddOneToList(list);

foreach (int i in list)
{
    Console.WriteLine(i);
}

Console.WriteLine($"Current object for listRef: {listRef}");

MakeListAddressNull(ref listRef);

Console.WriteLine($"Current object for listRef: {listRef}");

Console.ReadKey();

// Declare that the out parameter will be set inside the method
// Needs to assign a value to the parameter or it won't compile, even if it was initialized
// Argument doesn't need to have been initialized. (TryParse is an example of it.)
void MethodWithOutParameter(out int number)
{
    number = 10;
}

// Pass the argument by reference
// Parameter doesn't need to have a value assigned to it
// Argument needs to have been initialized before being passed
void AddOneToNumber(ref int number)
{
    ++number;
}

// If 'list' is turned into a null here, it will not be reflected on the variable at the top, but if we add a value to it, it will.
void AddOneToList(List<int> list) // 'list' Stores the address of it. If we set it to null, then we lose the reference in here.
{
    list.Add(1);
}

void MakeListAddressNull(ref List<int> list)
{
    list = null;
}