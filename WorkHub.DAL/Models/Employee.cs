namespace WorkHub.DAL.Models
{
    public class Employee
    {

        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? JobTitle { get; set; }
        //[ForeignKey("Department")] this is only needed if we use a different naming convention.
        // EF Core automatically recognizes foreign keys when property names follow the pattern <NavigationPropertyName>Id .
        // For example, 'DepartmentId' links to the 'Department' navigation property.
        public int DepartmentId { get; set; }

        // Navigation Property
        public Department? Department { get; set; }
    }
}
