using FluentValidation;
using UserApp.Service.Helpers;
using UserApp.Service.DTOs.RolePermissions;

namespace UserApp.Service.Validators.RolePermissions;

public class RolePermissionCreateModelValidator : AbstractValidator<RolePermissionCreateModel>
{
    public RolePermissionCreateModelValidator()
    {
        RuleFor(asset => asset.RoleId)
            .NotNull()
            .WithMessage(asset => $"{nameof(asset.RoleId)} is not specified");

        RuleFor(asset => asset.PermissionId)
           .NotNull()
           .WithMessage(asset => $"{nameof(asset.PermissionId)} is not specified");
    }
}