﻿using MediatR;

namespace DevFreela.Application.Commands.StartProject;

public class StartProjectCommand : IRequest
{
    public long IdProject { get; set; }
}
