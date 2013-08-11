// PostgresSQL Example
//
//
// requires a table to be created named employee
// with columns firstname and lastname
// such as,
//        CREATE TABLE employee (
//           firstname varchar(32),
//           lastname varchar(32));

using System;
using System.Data;
using Npgsql;


namespace PostgresSQLExample
{
	class MainClass
	{

		const string connectionString =
			"Server=localhost;" +
				"Database=mydb;" +
				"User ID=joe;" +
				"Password=test;";

		public static void Main (string[] args)
		{
			AddRecord ("Mike", "Hersh");
			ReadTable ();
			Console.ReadLine ();
		}


		public static void AddRecord(string firstName, string lastName) {
			IDbConnection dbcon;
			dbcon = new NpgsqlConnection(connectionString);
			dbcon.Open();
			IDbCommand dbcmd = dbcon.CreateCommand();

			string sql = "insert into employee values ('" + firstName + "', '" + lastName + "')";
			dbcmd.CommandText = sql;
			dbcmd.ExecuteScalar ();

			// clean up
			dbcmd.Dispose();
			dbcmd = null;
			dbcon.Close();
			dbcon = null;			
		}

		public static void ReadTable() {

			IDbConnection dbcon;
			dbcon = new NpgsqlConnection(connectionString);
			dbcon.Open();
			IDbCommand dbcmd = dbcon.CreateCommand();

			string sql =
				"SELECT firstname, lastname " +
					"FROM employee";
			dbcmd.CommandText = sql;
			IDataReader reader = dbcmd.ExecuteReader();
			while(reader.Read()) {
				string FirstName = reader.GetString(reader.GetOrdinal("firstname"));
				string LastName = reader.GetString(reader.GetOrdinal("lastname"));
				Console.WriteLine("Name: " +
				                  FirstName + " " + LastName);
			}
			// clean up
			reader.Close();
			reader = null;
			dbcmd.Dispose();
			dbcmd = null;
			dbcon.Close();
			dbcon = null;		
		}
	}
}
