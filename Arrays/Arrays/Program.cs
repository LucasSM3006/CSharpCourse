int[] numbers;
int[] numbers2 = new int[3];

numbers2[0] = 1;
numbers2[1] = 5;
numbers2[2] = 112;

Console.WriteLine(numbers2); // This will only print out the type/class

// Seems to be the exact same as how Java does it, except for a few new things, such as...

numbers2[^1] = 20; // This will grab the first index. It's the same as putting "0" to grab the first value.

// You can also declare them using 'var'.

var numbers3 = new [] { 1, 2, 3, 4, 5 };

PrintOutArray(numbers3);
PrintOutArray(numbers2);

Console.ReadKey();

void PrintOutArray(int[] array)
{
    int count = 0;
    foreach (int i in array)
    {
        Console.WriteLine($"Current index: {count}, Value held in index: {i}");
        count++;
    }
}