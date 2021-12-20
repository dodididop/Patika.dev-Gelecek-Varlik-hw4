using System;
namespace FutureAsset.Model
{
    public class UserViewModel
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public string PhoneNumber { get; set; }
    }
}
