using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsPerson
    {
        public enum enMode { AddNew = 0, Update = 1 };

        public enMode Mode = enMode.AddNew;

        public int PersonID { set; get; }
        public string FirstName { set; get; }
        public string SecondName { set; get; }
        public string ThirdName { set; get; }
        public string LastName { set; get; }
        public string FullName
        {
            get { return FirstName + " " + SecondName + " " + ThirdName + " " + LastName; }
        }

        public string NationalNo { set; get; }
        public string Address { set; get; }
        public string Phone { set; get; }
        public string Email { set; get; }
        public short Gendor { set; get; }
        public DateTime DateOfBirth { set; get; }
        public int NationalityCountryID { set; get; }
        public string ImagePath { set; get; }

        public clsCountry CountryInfo;


        public clsPerson()
        {
            Mode = enMode.AddNew;

            this.PersonID = -1;
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.DateOfBirth = DateTime.Now;
            this.Address = "";
            this.Phone = "";
            this.Email = "";
            this.NationalityCountryID = -1;
            this.ImagePath = "";

        }

        private clsPerson(int PersonID, string FirstName, string SecondName, string ThirdName,
                string LastName, string NationalNo, DateTime DateOfBirth, short Gendor,
                 string Address, string Phone, string Email,
                int NationalityCountryID, string ImagePath)

        {
            this.PersonID = PersonID;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.NationalNo = NationalNo;
            this.DateOfBirth = DateOfBirth;
            this.Gendor = Gendor;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalityCountryID = NationalityCountryID;
            this.ImagePath = ImagePath;
            this.CountryInfo = clsCountry.Find(NationalityCountryID);
            Mode = enMode.Update;
        }

        private bool _AddNewPerson()
        {
            this.PersonID = clsPersonData.AddNewPerson
                (
                    this.FirstName, this.SecondName, this.ThirdName, this.LastName,
                    this.NationalNo, this.DateOfBirth, this.Gendor, this.Address,
                    this.Phone, this.Email, this.NationalityCountryID, this.ImagePath
                );

            return (this.PersonID != -1);
        }



    }


}

