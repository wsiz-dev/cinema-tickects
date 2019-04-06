using System;
using System.Linq.Expressions;
using CinemaTickets.Domain;
using Hangfire;

namespace CinemaTickets.Infrastructure
{
    public class HangfireBackgroundJob : IBackgroundJob
    {
        public string Enqueue(Expression<Action> methodCall)
            => BackgroundJob.Enqueue(methodCall);
    }
}
