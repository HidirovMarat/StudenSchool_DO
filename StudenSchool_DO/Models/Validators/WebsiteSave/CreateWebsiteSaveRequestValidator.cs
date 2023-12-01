using FluentValidation;
using Models.Entitys;
using Models.Requests.WebsiteSave;
using Models.Validators.WebsiteSave.Interfaces;

namespace Models.Validators.WebsiteSave;

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
