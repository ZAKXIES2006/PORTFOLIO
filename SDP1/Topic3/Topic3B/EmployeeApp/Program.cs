using EmployeeApp;

var bill = new FullTimeEmployee("Bill", 60000m);
var fred = new Contractor("Fred", 50m, 40m);

Console.WriteLine("CalculatePay() ");
Console.WriteLine($"{bill.Name}: {bill.CalculatePay():C}");
Console.WriteLine($"{fred.Name}: {fred.CalculatePay():C}");

Console.WriteLine("\n GenerateReport()");
Console.WriteLine(bill.GenerateReport());
Console.WriteLine(fred.GenerateReport());

Console.WriteLine("\nPolymorphism: List<Employee> ");

List<Employee> staff = new()
{
    new FullTimeEmployee("Bill", 6250m),
    new Contractor("Fred", 50m, 40m),
    new FullTimeEmployee("Alice", 80000m),
    new Contractor("Sam", 75m, 20m)
};

foreach (Employee e in staff)
{
    decimal net = e.CalculatePay();
    decimal gross = net / (1 - Employee.TaxRate);
    decimal tax = gross * Employee.TaxRate;
    Console.WriteLine($"{e.Name}: Pay {gross:C}. Tax {tax:C}.");
}
