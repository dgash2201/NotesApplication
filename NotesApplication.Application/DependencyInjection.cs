using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using NotesApplication.Application.Common.Repository;
using NotesApplication.Application.Notes.Repository;
using NotesApplication.Application.Reminders.Repository;
using NotesApplication.Domain;
using System.Reflection;

namespace NotesApplication.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IRepository<Note>), typeof(NoteRepository));
            services.AddScoped(typeof(IRepository<Reminder>), typeof(ReminderRepository));
            services.AddMediatR(config =>
                    config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
