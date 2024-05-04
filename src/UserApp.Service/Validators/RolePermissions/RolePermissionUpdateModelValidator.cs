using FluentValidation;
using UserApp.Service.DTOs.RolePermissions;

namespace UserApp.Service.Validators.RolePermissions;

public class RolePermissionUpdateModelValidator : AbstractValidator<RolePermissionUpdateModel>
{
    public RolePermissionUpdateModelValidator()
    {
        RuleFor(asset => asset.RoleId)
            .NotNull()
            .WithMessage(asset => $"{nameof(asset.RoleId)} is not specified");

        RuleFor(asset => asset.PermissionId)
           .NotNull()
           .WithMessage(asset => $"{nameof(asset.PermissionId)} is not specified");
    }
}