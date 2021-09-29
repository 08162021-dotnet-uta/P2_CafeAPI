using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseLayer
{
    public partial class ViewModelCustomer
    {
        public ViewModelCustomer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public ViewModelCustomer(int id, string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = id;
        }
        public ViewModelCustomer() {}

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

   
    }
}
