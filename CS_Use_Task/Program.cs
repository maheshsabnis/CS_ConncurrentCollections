using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Use_Task
{
	class Program
	{
		static void Main(string[] args)
		{
			ListOperations operations = new ListOperations();
			Task t1 = Task.Run(()=> operations.AddList1());
			Task t2 = Task.Run(() => operations.AddList2());
			Task.WaitAll(t1,t2);
			operations.PrintLIst();
			Console.WriteLine("The Main Thread");
			Console.ReadLine();
		}
	}


	public class ListOperations
	{
		//ConcurrentBag<string> lstInt = new ConcurrentBag<string>();
		List<string> lstInt = new List<string>(); 

		public void AddList1()
		{
			for (int i = 0; i < 10; i++)
			{
				lstInt.Add($" Add list 1 ${i}");
			}
		}

		public void AddList2()
		{
			for (int i = 0; i < 10; i++)
			{
				lstInt.Add($" Add list 2 ${i}");
			}
		}

		public void PrintLIst()
		{
			foreach (string n in lstInt)
			{
				Console.WriteLine(n);
			}
		}
	}
}
