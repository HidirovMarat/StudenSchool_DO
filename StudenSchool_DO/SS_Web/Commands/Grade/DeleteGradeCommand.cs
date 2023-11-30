﻿using DbModels;
using Provider;
using SS_Web.Requests.Grade;
using SS_Web.Responses.GradeResponses;
using SS_Web.Validators.Grade.Interfaces;

namespace SS_Web.Commands.Grade;

public class DeleteGradeCommand
{
    private IDeleteGradeRequestValidator _validator;
    private DeleteGradeResponse _response;
    private GradeRepository _repository;

    public DeleteGradeCommand(IDeleteGradeRequestValidator validator, DeleteGradeResponse response, GradeRepository repository)
    {
        _validator = validator;
        _response = response;
        _repository = repository;
    }

    public DeleteGradeResponse Execute(DeleteGradeRequest request)
    {
        var resultValidation = _validator.Validate(request);

        if (!resultValidation.IsValid)
        {
            _response.Erorrs = resultValidation.Errors.Select(e => e.ErrorMessage).ToList();

            return _response;
        }

        if (!_repository.IsData(request.CourseId, request.StudentId))
        {
            _response.Erorrs.Add($"Не существует key1 = {request.StudentId} ||| key2 = {request.CourseId}");

            return _response;
        }

        _repository.Delete(request.StudentId, request.CourseId);

        return _response;
    }
}
