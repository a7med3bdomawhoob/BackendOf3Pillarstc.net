namespace DAL.Entities
{
    public class Job
    {
        public int Id { get; set; }     
        public string JobName { get; set; }
/*        [JsonIgnore]
        public ICollection<Book> Books { get; set; } // One-to-Many relationship with Book*/

    }
}
