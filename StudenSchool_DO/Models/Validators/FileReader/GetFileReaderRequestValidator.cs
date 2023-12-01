using FluentValidation;
using Models.Requests.FileReader;
using Models.Validators.FileReader.Interfaces;

namespace Models.Validators.FileReader;

public class GetFileReaderRequestValidator : AbstractValidator<GetFileReaderRequest>, IGetFileReaderRequestValidator
{
    public GetFileReaderRequestValidator()
    {

    }
}
