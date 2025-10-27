using FluentValidation;
using WorkHub.BLL.DTOs;

namespace WorkHub.API.Validators
{
    public class EmployeeValidator : AbstractValidator<EmployeeDTO>
    {
        public EmployeeValidator()
        {
            RuleFor(e => e.Id).NotEmpty().WithMessage("Required Id").NotNull();
            RuleFor(e => e.FullName).NotNull().NotEmpty().WithMessage("Fullname is required");
            RuleFor(e => e.DateOfBirth).NotEmpty();
            RuleFor(e => e.JobTitle).NotEmpty().MinimumLength(5).WithMessage("Job Title must be > 5 characters");
            RuleFor(e => e.DepartmentId).NotEmpty();
        }
    }
}
