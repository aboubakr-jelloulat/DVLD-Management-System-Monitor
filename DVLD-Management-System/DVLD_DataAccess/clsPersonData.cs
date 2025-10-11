using DVLD_DataAccess.DataAccessSettings;
using System;
using System.Data.SqlClient;


namespace DVLD_DataAccess
{

    public class clsPersonData
    {
        public static bool GetPersonInfoByID(int PersonID, ref string FirstName, ref string SecondName,
              ref string ThirdName, ref string LastName, ref string NationalNo, ref DateTime DateOfBirth,
               ref short Gendor, ref string Address, ref string Phone, ref string Email,
               ref int NationalityCountryID, ref string ImagePath)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection();

            string Query = "SELECT * FROM People WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    FirstName = (string)reader["FirstName"];


                    SecondName = (reader["SecondName"] != DBNull.Value) ? (string)reader["SecondName"] : null;

                    ThirdName = (reader["ThirdName"] != DBNull.Value) ? (string)reader["ThirdName"] : null;


                    LastName = (string)reader["LastName"];

                    NationalNo = (string)reader["NationalNo"];

                    DateOfBirth = (DateTime)reader["DateOfBirth"];

                    Gendor = (short)reader["Gendor"];

                    Address = (string)reader["Address"];

                    Phone = (string)reader["Phone"];

                    NationalityCountryID = (int)reader["NationalityCountryID"];


                    Email = (reader["Email"] != DBNull.Value) ? (string)reader["Email"] : null;

                    ImagePath = (reader["ImagePath"] != DBNull.Value) ? (string)reader["ImagePath"] : null;

                }

                reader.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Person Data Error : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }


            return IsFound;

        }

        public static bool GetPersonInfoByNationalNo(string NationalNo, ref int PersonID, ref string FirstName, ref string SecondName,
        ref string ThirdName, ref string LastName, ref DateTime DateOfBirth,
         ref short Gendor, ref string Address, ref string Phone, ref string Email,
         ref int NationalityCountryID, ref string ImagePath)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connstr);

            string query = "SELECT * FROM People WHERE NationalNo = @NationalNo";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    PersonID = (int)reader["PersonID"];

                    FirstName = (string)reader["FirstName"];


                    SecondName = (reader["SecondName"] != DBNull.Value) ? (string)reader["SecondName"] : null;

                    ThirdName = (reader["ThirdName"] != DBNull.Value) ? (string)reader["ThirdName"] : null;


                    LastName = (string)reader["LastName"];

                    DateOfBirth = (DateTime)reader["DateOfBirth"];

                    Gendor = (byte)reader["Gendor"];

                    Address = (string)reader["Address"];

                    Phone = (string)reader["Phone"];

                    NationalityCountryID = (int)reader["NationalityCountryID"];


                    Email = (reader["Email"] != DBNull.Value) ? (string)reader["Email"] : null;

                    ImagePath = (reader["ImagePath"] != DBNull.Value) ? (string)reader["ImagePath"] : null;

                }

                reader.Close();


            }
            catch (Exception ex)
            {
                Console.WriteLine("Person Data Error : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }


        public static int AddNewPerson(string FirstName, string SecondName,
           string ThirdName, string LastName, string NationalNo, DateTime DateOfBirth,
           short Gendor, string Address, string Phone, string Email,
            int NationalityCountryID, string ImagePath)
        {
            //this function will return the new person id if succeeded and -1 if not.

            int PersonID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connstr);

            string Query = @"INSERT INTO People (FirstName, SecondName, ThirdName,LastName,NationalNo,
                                                   DateOfBirth,Gendor,Address,Phone, Email, NationalityCountryID,ImagePath)
                             VALUES (@FirstName, @SecondName,@ThirdName, @LastName, @NationalNo,
                                     @DateOfBirth,@Gendor,@Address,@Phone, @Email,@NationalityCountryID,@ImagePath);
                             SELECT SCOPE_IDENTITY();";


            SqlCommand command = new SqlCommand(Query, connection);


            command.Parameters.AddWithValue("@FirstName", FirstName);


            command.Parameters.AddWithValue("@SecondName",
                    string.IsNullOrEmpty(SecondName) ? DBNull.Value : (object)SecondName);

            command.Parameters.AddWithValue("@ThirdName",
                    string.IsNullOrEmpty(ThirdName) ? DBNull.Value : (object)ThirdName);

            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);

            command.Parameters.AddWithValue("@Email",
                    string.IsNullOrEmpty(Email) ? DBNull.Value : (object)Email);

            command.Parameters.AddWithValue("@ImagePath",
                    string.IsNullOrEmpty(ImagePath) ? DBNull.Value : (object)ImagePath);


            try
            {
                connection.Open();

                /*
                 * the ?. operator in C# is called the null-conditional operator
                 * 
                 * it basically means: Only access this member if the object is not null; otherwise, return null immediate
                 * 
                 */


                object scalarValue = command.ExecuteScalar();

                if (scalarValue is int id)
                {
                    PersonID = id;
                }
                else if (int.TryParse(scalarValue?.ToString(), out int parsedId))
                {
                    PersonID = parsedId;
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("Person Data Error : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return (PersonID);
        }



        public static bool IsPersonExist(int PersonID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connstr);

            string Query = "SELECT Found = 1 FROM People WHERE PersonID = @PersonID;";


            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                IsFound = reader.HasRows;

                /*
                 * reader.HasRows is a boolean property (true or false).

                    It returns:

                        true → if there is at least one row in the result.

                        false → if the result is empty (no rows).
                */


                reader.Close();

            }
            catch(Exception ex)
            {
                Console.WriteLine("Person Data Error : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }


            return IsFound;
        }



        public static bool IsPersonExist(string NationalNo)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connstr);

            string Query = "SELECT Found = 1 FROM People WHERE NationalNo = @NationalNo;";


            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                IsFound = reader.HasRows;


                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Person Data Error : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }


            return IsFound;
        }

    }

}
