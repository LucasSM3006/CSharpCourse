﻿/*
 * Where & Distinct

Implement the GetFridaysOfYear method, which given a collection of dates and a number representing the year, returns a collection of all dates from this collection that are Fridays (without duplicates).

For example, for the following dates and year 2023:

    24.03.2023 (Friday)

    24.03.2023 (Friday) -> will be excluded as duplicate

    25.03.2023 (Saturday) -> will be excluded as not a Friday

    31.03.2023 (Friday)

    08.03.2024 (Friday) -> will be excluded because it's not from the given year

The result shall be:

    24.03.2023 (Friday)

    31.03.2023 (Friday)

Tip: The DateTime object has a DayOfWeek property of the DayOfWeek enum type.
 */

var fridays = new List<DateTime>
{
    new DateTime(2023, 03, 24),
    new DateTime(2023, 03, 24),
    new DateTime(2023, 03, 25),
    new DateTime(2023, 03, 31),
    new DateTime(2025, 03, 08),
};

var fridaysOfYear = Exercise.GetFridaysOfYear(2023, fridays);

foreach(var friday in fridaysOfYear)
{
    Console.WriteLine($"{friday.Day}.{friday.Month}.{friday.Year}");
}

Console.ReadKey();

public class Exercise
{
    public static IEnumerable<DateTime> GetFridaysOfYear(int year, IEnumerable<DateTime> dates)
    {
        return dates.Where(x => x.Year == year && x.DayOfWeek == DayOfWeek.Friday).Distinct();
    }
}