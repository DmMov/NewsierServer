using Newsier.Application.Interfaces;
using System;

namespace Newsier.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
