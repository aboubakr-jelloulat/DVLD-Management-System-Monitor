using DVLD_Business;
using DVLD_PresentationLayer.Notifications;
using System;
using System.IO;


namespace DVLD_PresentationLayer.Global
{
    internal static class clsGlobal
    {
        public static clsUser CurrentUser;


        public static bool RememberUsernameAndPassword(string Username, string Password)
        {
            try
            {
                //this will get the current project directory folder
                string currentDirectory = System.IO.Directory.GetCurrentDirectory();


                string filePath = currentDirectory + "\\data.txt";

                if (Username == "" && File.Exists(filePath))
                {
                    File.Delete(filePath);
                    return true;
                }

                // concatonate username and passwrod withe seperator.
                string dataToSave = Username + "#//#" + Password;


                // Create a StreamWriter to write to the file

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    // Write the data to the file

                    writer.WriteLine(dataToSave);

                    return true;
                }

            }
            catch (Exception ex)
            {
                clsMessageBoxHelper.ShowError("An error occurred: ", ex.Message);
                return false;
            }

        }


    }
}

