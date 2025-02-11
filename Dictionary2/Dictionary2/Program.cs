var employees = new List<Employee>
{
    new Employee("John Doe", "Human Resources", 2500),
    new Employee("Jhn Do", "IT", 4000),
    new Employee("Joh Do", "Engineering", 3200),
    new Employee("John D", "Engineering", 12000),
    new Employee("John H", "IT", 6000),
    new Employee("Jn Do", "IT", 7000),
};

var result = CalculateAverageSalaryByDepartment(employees);

foreach (var employee in result)
{
    Console.WriteLine(employee.Value);
}

Console.ReadKey();


Dictionary<string, decimal> CalculateAverageSalaryByDepartment(IEnumerable<Employee> employees)
{
    Dictionary<string, List<Employee>> employeesPerDepartments = new Dictionary<string, List<Employee>>(); // New dictionary, internal use only. Key will be the department.

    foreach (Employee employee in employees) // Iterating through the list of employees sent as a parameter.
    {
        if(!employeesPerDepartments.ContainsKey(employee.Department)) // If the dictionary doesn't have the department. (If does not contain key, we add new key, otherwise we do not, which means we'll use the same key for the employees in the same department.)
        {
            employeesPerDepartments[employee.Department] = new List<Employee>(); // Adding a new pair, Key is the Department, Value is a list.
        }

        employeesPerDepartments[employee.Department].Add(employee); // This grabs the list of employees stored by the Key value (Department), and then we add an employee to it.
    }

    var result = new Dictionary<string, decimal>(); // New dictionary, will store Keys as the Department, and the values as the average salary.

    foreach (var employeesPerDepartment in employeesPerDepartments) // It's a key value pair. Holds Key (Department) and the Value (List<Employee>)
    {
        decimal sumOfSalaries = 0; // Total sum of the salaries.
        
        foreach (Employee employee in employeesPerDepartment.Value) // We now iterate through the list held within the keyvaluepair.
        {
            sumOfSalaries += employee.MonthlySalary;
        }
        
        var average = sumOfSalaries / employeesPerDepartment.Value.Count; // Finally, calculate the average by the amount of employees in that department.

        result[employeesPerDepartment.Key] = average; // Alas, we add the average value to the key, which is the department.
    }

    return result;
}

public class Employee
{
    public Employee(string name, string department, decimal monthlySalary)
    {
        Name = name;
        Department = department;
        MonthlySalary = monthlySalary;
    }

    public string Name { get; init; }
    public string Department { get; init; }
    public decimal MonthlySalary { get; init; }
}