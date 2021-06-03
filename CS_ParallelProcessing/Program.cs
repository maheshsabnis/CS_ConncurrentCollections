using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CS_ParallelProcessing
{
	class Program
	{
		static void Main(string[] args)
		{
			Employees employees = new Employees();
			Console.WriteLine($"Sequential Operation Starts at ${DateTime.Now.ToString()}");

			var nonParallel = Stopwatch.StartNew();
			
			for (int i = 0; i < employees.Count; i++)
			{
				ProcessTax.CalculateTax(employees[i]);
				Console.WriteLine($"Sequential Tax Calculated ${employees[i].EmpNo} {employees[i].EmpName} {employees[i].Salary} {employees[i].Tax}");
			}
			Console.WriteLine($"Total Time for Sequential {nonParallel.Elapsed.TotalSeconds}");
			Console.WriteLine();
			Console.WriteLine();


			var parallel = Stopwatch.StartNew();
			Parallel.For(0, employees.Count, i =>
			{
				ProcessTax.CalculateTax(employees[i]);
				Console.WriteLine($"Parallel Tax Calculated ${employees[i].EmpNo} {employees[i].EmpName} {employees[i].Salary} {employees[i].Tax}");
			});
			Console.WriteLine($"Total Time for Parallel {parallel.Elapsed.TotalSeconds}");

			Console.ReadLine();
		}
	}

	public class Employee
	{
		public int EmpNo { get; set; }
		public string EmpName { get; set; }
		public int Salary { get; set; }
		public decimal Tax { get; set; }
	}

	public class Employees : List<Employee>
	{
		public Employees()
		{
			Add(new Employee() { EmpNo = 1, EmpName = "A", Salary = 11000});
			Add(new Employee() { EmpNo = 2, EmpName = "B", Salary = 12000 });
			Add(new Employee() { EmpNo = 3, EmpName = "C", Salary = 13000 });
			Add(new Employee() { EmpNo = 4, EmpName = "D", Salary = 14000 });
			Add(new Employee() { EmpNo = 5, EmpName = "E", Salary = 15000 });
			Add(new Employee() { EmpNo = 6, EmpName = "F", Salary = 16000 });
			Add(new Employee() { EmpNo = 7, EmpName = "G", Salary = 17000 });
			Add(new Employee() { EmpNo = 8, EmpName = "H", Salary = 18000 });
			Add(new Employee() { EmpNo = 9, EmpName = "I", Salary = 19000 });
			Add(new Employee() { EmpNo = 10, EmpName = "J", Salary = 20000 });
			Add(new Employee() { EmpNo = 11, EmpName = "K", Salary = 21000 });
			Add(new Employee() { EmpNo = 12, EmpName = "L", Salary = 22000 });
			Add(new Employee() { EmpNo = 13, EmpName = "M", Salary = 23000 });
			Add(new Employee() { EmpNo = 14, EmpName = "N", Salary = 24000 });
			Add(new Employee() { EmpNo = 15, EmpName = "O", Salary = 25000 });
			Add(new Employee() { EmpNo = 16, EmpName = "P", Salary = 26000 });
			Add(new Employee() { EmpNo = 17, EmpName = "Q", Salary = 27000 });
			Add(new Employee() { EmpNo = 18, EmpName = "R", Salary = 28000 });
			Add(new Employee() { EmpNo = 19, EmpName = "S", Salary = 29000 });
			Add(new Employee() { EmpNo = 20, EmpName = "T", Salary = 30000 });
			Add(new Employee() { EmpNo = 21, EmpName = "U", Salary = 31000 });
			Add(new Employee() { EmpNo = 22, EmpName = "V", Salary = 32000 });
			Add(new Employee() { EmpNo = 23, EmpName = "W", Salary = 33000 });
			Add(new Employee() { EmpNo = 24, EmpName = "X", Salary = 34000 });
			Add(new Employee() { EmpNo = 25, EmpName = "Y", Salary = 35000 });
			Add(new Employee() { EmpNo = 26, EmpName = "Z", Salary = 36000 });
			Add(new Employee() { EmpNo = 27, EmpName = "A", Salary = 37000 });
		}
	}

	public static class ProcessTax
	{
		public static Employee CalculateTax(Employee e)
		{
			Thread.Sleep(100);
			e.Tax = e.Salary * Convert.ToDecimal(0.2);
			return e;
		}
	}
}
