using System;
using System.Data.SQLite;

namespace SQLiteCountries
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadCountries();
        }

        private static void ReadCountries()
        {
            Database databaseObj = new Database();
            string query = "SELECT Country.countryName as Country, Capital.capitalname as Capital FROM Capital join Country on Capital.countryid = Country.rowid";
            SQLiteCommand myCommand = new SQLiteCommand(query, databaseObj.myConnection);
            databaseObj.OpenConnection();

            SQLiteDataReader data = myCommand.ExecuteReader();

            if (data.HasRows)
            {
                while (data.Read())
                {
                    Console.WriteLine($"Country: {data["country"]}. Capital: {data["Capital"]}");
                }
            }

            databaseObj.CloseConnection();
        }
    }
}
