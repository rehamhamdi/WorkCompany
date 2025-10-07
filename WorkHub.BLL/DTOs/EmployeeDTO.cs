using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkHub.BLL.DTOs
{
    public class EmployeeDTO
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [MinLength(2, ErrorMessage = "Name must be > 2 characters")]
        public string FullName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "Job Title must be > 5 characters")]
        public string? JobTitle { get; set; }
        public int? DepartmentId { get; set; }

    }
}
