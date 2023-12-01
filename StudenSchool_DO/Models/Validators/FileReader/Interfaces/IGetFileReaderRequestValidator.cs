using FluentValidation;
using Models.Requests.FileReader;

namespace Models.Validators.FileReader.Interfaces;

public interface IGetFileReaderRequestValidator : IValidator<GetFileReaderRequest>
{
}
