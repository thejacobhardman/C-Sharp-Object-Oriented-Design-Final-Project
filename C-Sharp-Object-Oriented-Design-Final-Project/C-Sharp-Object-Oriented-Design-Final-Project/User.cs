using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Object_Oriented_Design_Final_Project
{
    internal class User
    {
        public User()
        {
            FirstName = "placeholder";
            LastName = "placeholder";
            Role = "placeholder";
        }

        public User(string firstName, string lastName, string role)
        {
            FirstName = firstName;
            LastName = lastName;
            Role = role;
        }

        protected string FirstName; // Encapsulation

        protected string LastName; // Encapsulation

        protected string Role; // Encapsulation

        public string GetFirstName() { return FirstName; } // Encapsulation

        public string GetLastName() { return LastName; } // Encapsulation

        public string GetRole() { return Role; } // Encapsulation
    }
}
