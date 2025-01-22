/*
 * This application is a simple manager of TODOs.
 * Each TODO is simply a description of a thing to be done (for example, “Order a cake for the birthday party”).
 * Each description must be unique. TODOs can be added, removed, or listed. Should not allow duplicate TODOs
 */

List<string> todos = new List<string>();

bool runLoop = true;

do
{
    printWelcomeMessage();

    string userChoice = "";
    userChoice = Console.ReadLine();

    switch (userChoice.ToUpper())
    {
        case "S":
            printSelectedOption("See all TODOs");
            printList(todos);
            break;
        case "A":
            printSelectedOption("Adding a TODO");
            todos = add(todos);
            break;
        case "R":
            printSelectedOption("Remove a TODO");
            todos = remove(todos);
            break;
        case "E":
            printSelectedOption("Exit");
            runLoop = false;
            break;
        default:
            printSelectedOption("Invalid option.");
            break;
    }
} while (runLoop);


void printSelectedOption(string selectedOption)
{
    Console.WriteLine("Selected option: " + selectedOption);
}

void printList(List<string> list)
{
    int count = 0;

    if (list.Count == 0)
    {
        Console.WriteLine("No TODOs have been added yet.");
    }
    else
    {

        foreach (string item in list)
        {
            count++;
            Console.WriteLine($"{count}. {item}");
        }
    }
}

List<string> add(List<string> list)
{
    while (true)
    {
        Console.WriteLine("Enter a description for the Todo (must be unique and not empty)");
        string userChoice = Console.ReadLine();

        if (string.IsNullOrEmpty(userChoice.Trim()))
        {
            Console.WriteLine("Cannot add empty todos, retry");
            continue;
        }

        if (list.Contains(userChoice))
        {
            Console.WriteLine("Todo already present, retry");
            continue;
        }

        Console.WriteLine($"Todo with description: \"{userChoice}\" added.");
        list.Add(userChoice);
        break;
    }

    return list;
}

List<string> remove(List<string> list)
{
    if (list.Count == 0)
    {
        Console.WriteLine("No TODOs added yet.");
        return list;
    }

    while (true)
    {
        Console.WriteLine("Type the index of the todo you'd like to remove. (The index is the number at the front.)");
        string userChoice = Console.ReadLine();
        int index;
        bool isParsingSuccessful = int.TryParse(userChoice, out index);
        printList(list);

        if (isParsingSuccessful == false)
        {
            Console.WriteLine("Invalid index. Please enter a number.");
            continue;
        }

        if (index <= 0 || list.Count < index)
        {
            Console.WriteLine("Invalid index. Out of range.");
            continue;
        }

        list.RemoveAt(index - 1);
        break;
    }
    return list;
}

void printWelcomeMessage()
{
    Console.WriteLine("Hello, what would you like to do?");
    Console.WriteLine("[S]ee all TODOs");
    Console.WriteLine("[A]dd a TODO");
    Console.WriteLine("[R]emove a TODO");
    Console.WriteLine("[E]xit");
}