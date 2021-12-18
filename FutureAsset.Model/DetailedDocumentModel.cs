using System;
namespace FutureAsset.Model
{
    public class DetailedDocumentModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string DocNumber { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime DocDate { get; set; }
    }
}
