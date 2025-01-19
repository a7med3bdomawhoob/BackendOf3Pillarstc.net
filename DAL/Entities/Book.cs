using System.ComponentModel.DataAnnotations;
namespace DAL.Entities
{
    public  class Book
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "name is Required")]
      /*  [StringLength(maximumLength: 100, MinimumLength = 5, ErrorMessage = "name must be more than 5 and less100")]*/
        public string FullName { get; set; }
        public int JobId { get; set; }
        public Job Job { get; set; } // Navigation property
        public int DepartmentId { get; set; }
        public Department Department { get; set; } // Navigation property
        public string MobileNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhotoUrl { get; set; }
        public int age { get; set; }
    }
}
