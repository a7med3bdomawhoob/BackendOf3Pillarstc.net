namespace HubTask.Models
{
    public class BookDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int ?JobId { get; set; }
        public int DepartmentId { get; set; }
        public string MobileNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int age { get; set; }
      /*public int Age => DateTime.Now.Year - DateOfBirth.Year - (DateTime.Now.DayOfYear < DateOfBirth.DayOfYear ? 1 : 0); */
        public string ? PhotoUrl { get; set; }
        public IFormFile ? Image { get; set; }   //upload files on it 
    }
}
