namespace UnitOfWorks.Models
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set;}
    }
}
