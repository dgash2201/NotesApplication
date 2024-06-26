﻿using MediatR;
using NotesApplication.Application.Common.Responses;
using NotesApplication.Domain;

namespace NotesApplication.Application.Tags.Commands.Create
{
    public class CreateTagCommand : IRequest<Response<Tag>>
    {
        public required string Name { get; set; }
    }
}
