using System;
using System.Collections.Generic;

#nullable disable

namespace ModelsLayer.EfModels
{
    public partial class Administrator
    {
        public Administrator()
        {
            SignIns = new HashSet<SignIn>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Role { get; set; }

        public virtual ICollection<SignIn> SignIns { get; set; }
    }
}
