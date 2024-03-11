using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Birth
    {        
        public int Id { get; set; }
        public string FirstName { get; set; }
      
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
