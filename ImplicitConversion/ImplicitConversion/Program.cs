int seasonNumber = 0;
Season spring = (Season)seasonNumber; // Implicit conversion.

int integer = 10;
decimal b = integer; // Implicit conversion. Safe and lossless conversions.

decimal dec = 10.01m;
int integ = (int) dec; // Explicit conversion. Not safe, might have losses.

// The compiler sometimes won't know about possible errors as well, such as...

// decimal a1 = 10000000000.01m;
// int b1 = (int) a1;

// The code above will compile, but upon running, will throw an exception!

// string s = (string)integer; // However, the compiler can sometimes know ahead of time whether it'll fail or not.

int secondSeasonNumber = 1; // The thing is, this number could be something out of range on the enum, like 100, and it'd still compile and run. It'd print out 100, and the enum type would still be assigned to 'summer'.

Season summer = (Season)secondSeasonNumber;

Console.WriteLine(summer);

Console.ReadKey();


public enum Season
{
    Spring,
    Summer,
    Autumn,
    Winter
}

