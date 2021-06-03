using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CS_TaskBasedOperation
{
	class Program
	{
		static async Task Main(string[] args)
		{
			FileOperation file = new FileOperation();
			await file.ManipulateFile(@"c:\MyFile.txt");
			Console.ReadLine();
		}
	}

	public class FileOperation
	{
		public async Task ManipulateFile(string fileName)
		{
			try
			{
				using (Stream streamWrite = new FileStream(fileName, FileMode.CreateNew, FileAccess.Write))
				{
					var sw = new StreamWriter(streamWrite);
					await sw.WriteAsync("The Data is Written in the File");
					Console.WriteLine($"Data is writen to the File ");
					sw.Close();
				}

				using (Stream streamRead = new FileStream(fileName,FileMode.Open ,FileAccess.Read))
				{
					var sr = new StreamReader(streamRead);
					var data = await sr.ReadToEndAsync();
					Console.WriteLine($"Data Read from File {data}");
					sr.Close();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error Occured in Manipulation {ex.Message}");
			}
		}
	}
}
