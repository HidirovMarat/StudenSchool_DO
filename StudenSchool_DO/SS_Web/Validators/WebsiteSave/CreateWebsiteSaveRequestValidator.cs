using FluentValidation;
using SS_Web.Entitys;
using SS_Web.Requests.WebsiteSave;
using SS_Web.Validators.WebsiteSave.Interfaces;

namespace SS_Web.Validators.WebsiteSave;

public class CreateWebsiteSaveRequestValidator : AbstractValidator<CreateWebsiteSaveRequest>, ICreateWebsiteSaveRequestValidator
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
