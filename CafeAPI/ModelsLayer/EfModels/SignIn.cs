using System;
using System.Collections.Generic;

#nullable disable

namespace ModelsLayer.EfModels
{
    public partial class SignIn
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? CustomerId { get; set; }
        public int? AdministratorId { get; set; }

        public virtual Administrator Administrator { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
