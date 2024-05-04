using FluentValidation;
using UserApp.Service.Helpers;
using UserApp.Service.DTOs.Assets;

namespace UserApp.Service.Validators.Assets;

public class AssetCreateModelValidator : AbstractValidator<AssetCreateModel>
{
    public AssetCreateModelValidator()
    {
        RuleFor(asset => asset.FileType)
            .NotNull()
            .IsInEnum()
            .WithMessage(asset => $"{nameof(asset.FileType)} is not specified");

        RuleFor(asset => asset.File)
            .Must(ValidationHelper.IsFileValid);
    }
}
