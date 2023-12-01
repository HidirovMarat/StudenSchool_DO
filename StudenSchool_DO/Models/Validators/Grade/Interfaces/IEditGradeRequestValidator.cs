﻿using FluentValidation;
using Models.Requests.Grade;

namespace Models.Validators.Grade.Interfaces;

public interface IEditGradeRequestValidator : IValidator<EditGradeRequest>
{
}