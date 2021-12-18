using System;
using System.Collections.Generic;

#nullable disable

namespace FutureAsset.DB.Entities
{
    public partial class User
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public string PhoneNumber { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
