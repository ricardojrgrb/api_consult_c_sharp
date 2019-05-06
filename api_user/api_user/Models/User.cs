using System;
namespace api_user.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Reason { get; set; }
        public decimal Value { get; set; }
        public string Date { get; set; }
    }
}
