using FluentValidation;
using SS_Web.Entitys;
using SS_Web.Validators.@base;

namespace SS_Web.Validators;

public class CreateWebsiteSaveRequestValidator : AbstractValidator<WebsiteSaveInfo>, ICreateWebsiteSaveRequestValidator
{
    public CreateWebsiteSaveRequestValidator()
    {
        RuleFor(request => request.Path)
            .NotEmpty()
            .WithMessage("Paht должно быть указано!")
            .Must(a => !File.Exists(a))
            .WithMessage("Нет такого path");
    }
}
