namespace DAL.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
      /*  [JsonIgnore] 
       *  public ICollection<Book> Books { get; set; }*/
    }
}
