﻿using Models.Requests.Grade;
using Models.Responses.GradeResponses;

namespace SS_WEB.Commands.Grade.Interfaces;

public interface IDeleteGradeCommand
{
    public DeleteGradeResponse Execute(DeleteGradeRequest request);
}