﻿using MediatR;
using NotesApplication.Application.Common.Response;
using NotesApplication.Domain;

namespace NotesApplication.Application.Reminders.Queries.Get
{
    public class GetReminderQuery : IRequest<Response<Reminder>>
    {
        public int Id { get; set; }
    }
}
