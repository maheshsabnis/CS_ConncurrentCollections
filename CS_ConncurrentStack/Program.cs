using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using Newtonsoft.Json;

namespace CS_ConncurrentStack
{
	class Program
	{
		static void Main(string[] args)
		{
		
			ListOperations lst = new ListOperations();

			ThreadStart t1 = new ThreadStart(lst.AddList1);
			Thread tt1 = new Thread(t1);
			tt1.Start();

			ThreadStart t2 = new ThreadStart(lst.AddList2);
			Thread tt2 = new Thread(t2);
			tt2.Start();

			lst.PrintLIst();
			Console.WriteLine("The Main App");
			Console.ReadLine();
		}
	}

	public class ListOperations
	{
		  ConcurrentBag<string> lstInt = new ConcurrentBag<string>();
		 // List<string> lstInt = new List<string>();

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
