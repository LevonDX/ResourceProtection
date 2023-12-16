namespace ResourceProtection
{
	internal class Program
	{
		const string FILE_NAME = "test.txt";
		private static readonly object _lock = new object();

		static void WriteToFile()
		{
			lock (_lock)
			{
				using (StreamWriter sw = new StreamWriter(FILE_NAME, true))
				{
					for (int i = 0; i < 1E05; i++)
					{
						sw.WriteLine(i);
					}
				}
			}
		}


		static void ReadFromFile()
		{
			lock (_lock)
			{
				using (StreamReader sr = new StreamReader(FILE_NAME))
				{
					string line;
					while ((line = sr.ReadLine()!) != null)
					{
						Console.WriteLine(line);
					}
				}
			}
		}

		static void Main(string[] args)
		{
			Thread tWrite = new Thread(WriteToFile); 
			Thread tWrite1 = new Thread(WriteToFile);
			Thread tWrite2= new Thread(WriteToFile);
			Thread tWrite3 = new Thread(WriteToFile);
			Thread tWrite4 = new Thread(WriteToFile);
			Thread tWrite5 = new Thread(WriteToFile);
			Thread tWrite6 = new Thread(WriteToFile);

			// give name to threads numbered
			tWrite.Name = "Thread 1";
			tWrite1.Name = "Thread 2";
			tWrite2.Name = "Thread 3";
			tWrite3.Name = "Thread 4";
			tWrite4.Name = "Thread 5";
			tWrite5.Name = "Thread 6";
			tWrite6.Name = "Thread 7";


			tWrite.Start();
			tWrite1.Start();
			tWrite2.Start();
			tWrite3.Start();
			tWrite4.Start();
			tWrite5.Start();
			tWrite6.Start();
			//Thread tRead = new Thread(ReadFromFile);
			//tWrite.Start();
			//tRead.Start();

			//tWrite.Join();
			//tRead.Join();
		}
	}
}