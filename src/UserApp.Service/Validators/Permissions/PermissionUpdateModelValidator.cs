using FluentValidation;
using UserApp.Service.DTOs.Permissions;

namespace UserApp.Service.Validators.Permissions;

public class PermissionUpdateModelValidator : AbstractValidator<PermissionUpdateModel>
{
    public PermissionUpdateModelValidator()
    {
        RuleFor(role => role.Action)
            .NotNull()
            .WithMessage(role => $"{nameof(role.Action)} is not specified");

        RuleFor(role => role.Controller)
           .NotNull()
           .WithMessage(role => $"{nameof(role.Controller)} is not specified");
    }
}