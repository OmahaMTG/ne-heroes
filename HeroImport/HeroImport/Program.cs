using System.Data;
using System.Globalization;
using ExcelDataReader;

using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;


namespace HeroImport
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using var stream = File.Open(@".\FALLEN HEROES DATABASE2.xlsx", FileMode.Open, FileAccess.Read);
            using var reader = ExcelReaderFactory.CreateReader(stream);
            var result = reader.AsDataSet(new ExcelDataSetConfiguration()
            {
                ConfigureDataTable = dataReader => new ExcelDataTableConfiguration()
                {
                    UseHeaderRow = true
                }
            });

            var heroes = new List<Hero>();
            foreach (DataRow dataRow in result.Tables[0].Rows)
            {
                Hero hero = new Hero();

                hero.Id = Convert.ToInt32(dataRow["Id"] == DBNull.Value ? 0 : dataRow["Id"]);
                hero.OriginCounty = dataRow["OriginCounty"]?.ToString();
                hero.TreeSite = dataRow["TreeSite"].ToString();
                hero.Rank = dataRow["Rank"].ToString();
                hero.FirstName = dataRow["FirstName"].ToString();
                hero.MiddleName = dataRow["MiddleName"].ToString();
                hero.LastName = dataRow["LastName"].ToString();
                hero.War = dataRow["War"].ToString();
                hero.MilitaryBranch = dataRow["MilitaryBranch"].ToString();
                hero.FirstResponderType = dataRow["FirstResponderType"].ToString();
                hero.BirthDate = GetDateFromRow(dataRow, "BirthDate");
                hero.DateOfDeath = GetDateFromRow(dataRow, "DateOfDeath");
                hero.CauseOfDeath = dataRow["CauseOfDeath"].ToString();
                hero.LocationOfDeath = dataRow["LocationOfDeath"].ToString();
                hero.OriginCity = dataRow["OriginCity"].ToString();
                hero.OriginState = dataRow["OriginState"].ToString();
                hero.FlagStatus = dataRow["FlagStatus"].ToString();
                hero.FlagReceiveStatus = dataRow["FlagReceiveStatus"].ToString();
                hero.FlagReceivedDate = GetDateFromRow(dataRow, "FlagReceivedDate");
                hero.FlagSponsor = dataRow["FlagSponsor"].ToString();
                hero.OriginLocation = dataRow["OriginLocation"].ToString();
                hero.Notes = dataRow["Notes"].ToString();

                heroes.Add(hero);


            }
            var connString = "Server=tcp:neheroes.database.windows.net,1433;Initial Catalog=heroes2;Persist Security Info=False;User ID=mattruwe;Password=P@ssw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            //using SqlConnection connection = new SqlConnection(connString);
            //connection.Open();
            //using SqlCommand command = new SqlCommand();
            //command.Connection = connection;
            //command.CommandType = CommandType.Text;
            //command.CommandText = "SET IDENTITY_INSERT Heroes ON";
            //command.ExecuteNonQuery();
            
            foreach (var hero in heroes)
            {
                
                InsertOrUpdateHero(hero, connString);
            }
            
            //command.CommandText = "SET IDENTITY_INSERT Heroes OFF";
            //command.ExecuteNonQuery();

        }

        public static void InsertOrUpdateHero(Hero hero, string connectionString)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            using SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;

            // Check if the record exists
            command.CommandText = "SELECT COUNT(1) FROM Heroes WHERE Id = @Id";
            command.Parameters.AddWithValue("@Id", (object)hero.Id ?? DBNull.Value);

            int count = (int)command.ExecuteScalar();

            if (count > 0)
            {
                Console.WriteLine($"Update record with id: {hero.Id}");
                // Update existing record
                command.CommandText = @"
                    UPDATE Heroes
                    SET 
                        OriginCounty = @OriginCounty,
                        TreeSite = @TreeSite,
                        Rank = @Rank,
                        FirstName = @FirstName,
                        MiddleName = @MiddleName,
                        LastName = @LastName,
                        War = @War,
                        MilitaryBranch = @MilitaryBranch,
                        FirstResponderType = @FirstResponderType,
                        BirthDate = @BirthDate,
                        DateOfDeath = @DateOfDeath,
                        CauseOfDeath = @CauseOfDeath,
                        LocationOfDeath = @LocationOfDeath,
                        OriginCity = @OriginCity,
                        OriginState = @OriginState,
                        FlagStatus = @FlagStatus,
                        FlagReceiveStatus = @FlagReceiveStatus,
                        FlagReceivedDate = @FlagReceivedDate,
                        FlagSponsor = @FlagSponsor,
                        OriginLocation = @OriginLocation,
                        Notes = @Notes
                    WHERE Id = @Id";
            }
            else
            {
                Console.WriteLine($"Insert new record.");
                // Insert new record
                command.CommandText = @"
                    INSERT INTO Heroes (
                        OriginCounty, TreeSite, Rank, FirstName, MiddleName, LastName, War, MilitaryBranch, 
                        FirstResponderType, BirthDate, DateOfDeath, CauseOfDeath, LocationOfDeath, OriginCity, 
                        OriginState, FlagStatus, FlagReceiveStatus, FlagReceivedDate, FlagSponsor, OriginLocation, Notes
                    ) VALUES (
                        @OriginCounty, @TreeSite, @Rank, @FirstName, @MiddleName, @LastName, @War, @MilitaryBranch, 
                        @FirstResponderType, @BirthDate, @DateOfDeath, @CauseOfDeath, @LocationOfDeath, @OriginCity, 
                        @OriginState, @FlagStatus, @FlagReceiveStatus, @FlagReceivedDate, @FlagSponsor, @OriginLocation, @Notes
                    )";
            }

            // Add parameters
            command.Parameters.AddWithValue("@OriginCounty", (object)hero.OriginCounty ?? DBNull.Value);
            command.Parameters.AddWithValue("@TreeSite", (object)hero.TreeSite ?? DBNull.Value);
            command.Parameters.AddWithValue("@Rank", (object)hero.Rank ?? DBNull.Value);
            command.Parameters.AddWithValue("@FirstName", (object)hero.FirstName ?? DBNull.Value);
            command.Parameters.AddWithValue("@MiddleName", (object)hero.MiddleName ?? DBNull.Value);
            command.Parameters.AddWithValue("@LastName", (object)hero.LastName ?? DBNull.Value);
            command.Parameters.AddWithValue("@War", (object)hero.War ?? DBNull.Value);
            command.Parameters.AddWithValue("@MilitaryBranch", (object)hero.MilitaryBranch ?? DBNull.Value);
            command.Parameters.AddWithValue("@FirstResponderType", (object)hero.FirstResponderType ?? DBNull.Value);
            command.Parameters.AddWithValue("@BirthDate", (object)hero.BirthDate ?? DBNull.Value);
            command.Parameters.AddWithValue("@DateOfDeath", (object)hero.DateOfDeath ?? DBNull.Value);
            command.Parameters.AddWithValue("@CauseOfDeath", (object)hero.CauseOfDeath ?? DBNull.Value);
            command.Parameters.AddWithValue("@LocationOfDeath", (object)hero.LocationOfDeath ?? DBNull.Value);
            command.Parameters.AddWithValue("@OriginCity", (object)hero.OriginCity ?? DBNull.Value);
            command.Parameters.AddWithValue("@OriginState", (object)hero.OriginState ?? DBNull.Value);
            command.Parameters.AddWithValue("@FlagStatus", (object)hero.FlagStatus ?? DBNull.Value);
            command.Parameters.AddWithValue("@FlagReceiveStatus", (object)hero.FlagReceiveStatus ?? DBNull.Value);
            command.Parameters.AddWithValue("@FlagReceivedDate", (object)hero.FlagReceivedDate ?? DBNull.Value);
            command.Parameters.AddWithValue("@FlagSponsor", (object)hero.FlagSponsor ?? DBNull.Value);
            command.Parameters.AddWithValue("@OriginLocation", (object)hero.OriginLocation ?? DBNull.Value);
            command.Parameters.AddWithValue("@Notes", (object)hero.Notes ?? DBNull.Value);

            // Execute the command
            command.ExecuteNonQuery();
        }


        private static DateTime? GetDateFromRow(DataRow dataRow, string columnName)
        {
            var returnDateString = dataRow[columnName] == DBNull.Value ? null : dataRow[columnName].ToString();

            if (DateTime.TryParse(returnDateString, out DateTime returnValue))
                return returnValue;
            return null;
        }
    }


}
