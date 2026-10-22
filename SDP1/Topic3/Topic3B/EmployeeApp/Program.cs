using EmployeeApp;

var bill = new FullTimeEmployee("Bill", 60000m);
var fred = new Contractor("Fred", 50m, 40m);

Console.WriteLine("CalculatePay() ");
Console.WriteLine($"{bill.Name}: {bill.CalculatePay():C}");
Console.WriteLine($"{fred.Name}: {fred.CalculatePay():C}");

Console.WriteLine("\n GenerateReport()");
Console.WriteLine(bill.GenerateReport());
Console.WriteLine(fred.GenerateReport());
