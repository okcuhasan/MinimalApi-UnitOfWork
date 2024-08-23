namespace UnitOfWorks.Models
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }
        public Decimal Salary { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
