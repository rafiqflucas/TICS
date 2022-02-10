using System;


namespace TICS.Models
{
    public class  Person
    {

        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string UserName { get; set; }

        public string EmailAddress { get; set; }

        public string PasswordHash { get; set; }

        public bool IsEmailConfirmed { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime RegistrationDate { get; set; }

        public DateTime EmailVerificationDate { get; set; }

        public int UserType { get; set; }


    }
}
