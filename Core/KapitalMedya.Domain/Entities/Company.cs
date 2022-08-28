using KapitalMedya.Domain.Entities.Common;

namespace KapitalMedya.Domain.Entities
{
    public class Company : BaseEntity
    {
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public string? Address { get; set; }
        public float? Salary { get; set; }
    }
}
