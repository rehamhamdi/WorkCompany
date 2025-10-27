﻿namespace WorkHub.BLL.DTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? JobTitle { get; set; }
        public int? DepartmentId { get; set; }

    }
}
