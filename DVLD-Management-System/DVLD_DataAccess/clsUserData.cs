using DVLD_DataAccess.DataAccessSettings;
using System;
using System.Data.SqlClient;


namespace DVLD_DataAccess
{
    public class clsUserData
    {

        public static bool GetUserInfoByUserID(int UserID, ref int PersonID, 
                ref string UserName, ref string Password, ref bool IsActive)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connstr);

            string Query = "SELECT * FROM Users WHERE UserID = @UserID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    PersonID = (int)reader["PersonID"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["IsActive"];

                    IsFound = true;
                }

                reader.Close();

            }

            catch(Exception ex)
            {
                Console.WriteLine("User Data Error : " + ex.Message);

            }
            finally
            {
                connection.Close();
            }


            return IsFound;
        }



        public static bool GetUserInfoByPersonID(int PersonID, ref int UserID,
                ref string UserName, ref string Password, ref bool IsActive)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connstr);

            string Query = "SELECT * FROM Users WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    UserID   = (int)reader["UserID"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["IsActive"];

                    IsFound = true;
                }

                reader.Close();

            }

            catch (Exception ex)
            {
                Console.WriteLine("User Data Error : " + ex.Message);

            }
            finally
            {
                connection.Close();
            }


            return IsFound;
        }


        public static bool GetUserInfoByUsernameAndPassword(string UserName, string Password,
            ref int UserID, ref int PersonID, ref bool IsActive)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connstr);

            string Query = "SELECT * FROM Users WHERE  UserName = @UserName AND Password = @Password;";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                
                if(reader.Read())
                {
                    UserID   = (int)reader["UserID"];
                    PersonID = (int)reader["PersonID"];
                    IsActive = (bool)reader["IsActive"];

                    IsFound = true;
                }


            }

            catch(Exception ex)
            {
                Console.WriteLine("User Data Error : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }


            return (IsFound);
        }



    }

}
