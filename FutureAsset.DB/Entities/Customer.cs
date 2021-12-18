using System;
using System.Collections.Generic;

#nullable disable

namespace FutureAsset.DB.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Document = new HashSet<Document>();
            User = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<Document> Document { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
