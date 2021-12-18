using System;
using System.Collections.Generic;

#nullable disable

namespace FutureAsset.DB.Entities
{
    public partial class Document
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public string Type { get; set; }
        public string DocNumber { get; set; }
        public DateTime DocDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModificationDate { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
