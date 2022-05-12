// See https://aka.ms/new-console-template for more information
using ConsoleApp1;

Console.WriteLine("Hello, World!");

var employees = Processor.ImportEmployees();
var customers = Processor.ImportCustomers();


Console.WriteLine(employees);
Console.WriteLine(customers);