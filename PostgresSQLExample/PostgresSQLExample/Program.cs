using System;

namespace PostgresSQLExample
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			MyDB.AddRecord ("Mike", "Hersh");
			MyDB.ReadTable ();
			Console.ReadLine ();
		}
	}
}
