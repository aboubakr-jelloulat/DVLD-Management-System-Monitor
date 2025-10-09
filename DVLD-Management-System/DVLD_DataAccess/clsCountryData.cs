using DVLD_DataAccess.DataAccessSettings;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;


namespace DVLD_DataAccess
{
    public class clsCountryData
    {
        public enum enGendor 
        {
            Male = 0,
            Female = 1
        };


        public static bool GetCountryInfoByID(int ID, ref string CountryName)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connstr);

            string Query = "SELECT * FROM Countries WHERE CountryID = @CountryID;";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@CountryID", ID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    CountryName = (string)reader["CountryName"];

                }

                reader.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Country Data Error : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return IsFound;

        }

        public static bool GetCountryInfoByName(string CountryName, ref int ID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connstr);

            string Query = "SELECT * FROM Countries WHERE CountryName = @CountryName;";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.Add("@CountryName", CountryName);

            try 
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    ID = (int)reader["CountryID"];
                }

                reader.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Country Data Error : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static DataTable GetAllCountries()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connstr);

            string Query = "SELECT * FROM Countries ;";

            SqlCommand command = new SqlCommand(Query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

                reader.Close();

            }
            catch(Exception ex)
            {
                Console.WriteLine("Country Data Error : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

    }
}
