
using System.ComponentModel.DataAnnotations;

namespace PostAPI.Models
{
    public class Company
    {
        public int Id { get; set; }
        [Required]
        //[MaxLength(35)]
        //[MinLength(5)]
        public string companyName { get; set; }
        [Required]
        public int numberOfEmployees { get; set; }
        [Required]
        public int averageSalary { get; set; }
    }

}
