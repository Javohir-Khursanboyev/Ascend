using FluentValidation;
using UserApp.Service.DTOs.Roles;

namespace UserApp.Service.Validators.Roles;

public class RoleCreateModelValidator : AbstractValidator<RoleCreateModel>
{
    public RoleCreateModelValidator()
    {
        RuleFor(role => role.Name)
            .NotNull()
            .WithMessage(role => $"{nameof(role.Name)} is not specified");
    }
}