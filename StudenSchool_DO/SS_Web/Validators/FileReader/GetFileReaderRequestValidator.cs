using FluentValidation;
using SS_Web.Requests.FileReader;
using SS_Web.Validators.FileReader.Interfaces;

namespace SS_Web.Validators.FileReader;

public class GetFileReaderRequestValidator : AbstractValidator<GetFileReaderRequest>, IGetFileReaderRequestValidator
{
    public GetFileReaderRequestValidator()
    {

    }
}
