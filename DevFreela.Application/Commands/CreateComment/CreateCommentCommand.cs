﻿using MediatR;

namespace DevFreela.Application.Commands.CreateComment;

public class CreateCommentCommand : IRequest<long>
{
    public long IdUser { get; set; }
    public long IdProject { get; set; }
    public string Content { get; set; }
}
